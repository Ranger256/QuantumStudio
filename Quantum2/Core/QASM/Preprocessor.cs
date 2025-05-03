using System;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Quantum2.Core.QASM
{
    public class Preprocessor
    {
        private Dictionary<string, List<string>> _defines;

        private List<List<string>> _parts;

        private bool _br;
        private Stack<bool> _brs;

        public List<List<string>> Parts
        {
            get
            {
                return _parts;
            }
        }

        public Preprocessor()
        {
            _defines = new Dictionary<string, List<string>>();

            _parts = new List<List<string>>();

            _br = true;
            _brs = new Stack<bool>();
        }

        public void Execute(string text)
        {
            string[] lines = text.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
          
            for(int i = 0; i < lines.Length;i++)
            {

                AnalyzeParts(SplitLine(lines[i]));
            }

            foreach(var define in _defines)
            {
                for(int j = 0; j < _parts.Count;j++)
                {
                    for(int z = 0; z < _parts[j].Count;z++)
                    {
                        if(_parts[j][z] == define.Key)
                        {
                            _parts[j].RemoveAt(z);
                            _parts[j].InsertRange(z, define.Value);
                        }
                    }
                }
            }
        }

        public void Reset()
        {
            _defines.Clear();

            _brs.Clear();

            _parts.Clear();

            _br = true;
        }

        private List<string> SplitLine(string line)
        {
            string[] lines = Regex.Split(line, @"(\ |\[|\]|\,|\#|\$|\;|\'|\+|\-|\*|\/|\^|\~|\=|\:|\(|\))");

            lines = Array.FindAll(lines, l => (l != " " && l != "") );

            return new List<string>(lines);
        }

        private void RemoveComments(List<string> parts)
        {

            for (int i = 0; i < parts.Count; i++)
            {
                if (parts[i] == ";")
                {
                    parts.RemoveRange(i, parts.Count - i);

                    continue;
                }
            }
        }

        private void ProcessSourceDefine(List<string> source)
        {
            for (int i = 0; i < source.Count; i++)
            {
                if (_defines.ContainsKey(source[i]))
                {
                    string nameDefine = source[i];

                    source.RemoveAt(i);
                    source.InsertRange(i, _defines[nameDefine]);
                }
            }
        }

        private void AddDefine(string name, List<string> source)
        {
            ProcessSourceDefine(source);

            _defines.Add(name, source);
        }

        private void SetDefine(string name, List<string> source)
        {
            ProcessSourceDefine(source);

            _defines[name] = source;
        }

        private void AnalyzeParts(List<string> parts)
        {
            RemoveComments(parts);

            if (parts.Count > 0)
            {
                if (parts[0] == "#")
                {
                    if (_br)
                    {
                        switch (parts[1])
                        {
                            case "include":
                                {
                                    string includeFileName = "";

                                    if (parts[2] != "'")
                                    {
                                        //error
                                    }

                                    int i = 3;

                                    while (parts[i] != "'")
                                    {

                                        includeFileName += parts[i];

                                        i++;

                                        if (i == parts.Count)
                                        {
                                            //error
                                            return;
                                        }
                                    }

                                    if (!File.Exists(includeFileName))
                                    {
                                        //error
                                    }

                                    string[] linesFile = File.ReadAllLines(includeFileName);

                                    for (int j = 0; j < linesFile.Length; j++)
                                    {
                                        AnalyzeParts(SplitLine(linesFile[j]));
                                    }

                                    break;
                                }
                            case "define":
                                {
                                    if (parts.Count > 3)
                                    {
                                        AddDefine(parts[2], parts.GetRange(3, parts.Count - 3));
                                        //_defines.Add(parts[2], parts.GetRange(3, parts.Count - 3));
                                    }
                                    else
                                    {
                                        _defines.Add(parts[2], new List<string>());
                                    }

                                    break;
                                }
                            case "assign":
                                {
                                    if (_defines.ContainsKey(parts[2]))
                                    {
                                        if (parts.Count > 3)
                                            SetDefine(parts[2], parts.GetRange(3, parts.Count - 3));
                                        //_defines[parts[2]] = parts.GetRange(3, parts.Count - 3);
                                        else
                                            _defines[parts[2]] = new List<string>();
                                    }
                                    else
                                    {
                                        //error
                                    }

                                    break;
                                }
                            case "undef":
                                {
                                    if (_defines.ContainsKey(parts[2]))
                                    {
                                        _defines.Remove(parts[2]);
                                    }
                                    else
                                    {
                                        //error
                                    }

                                    break;
                                }

                            case "rep":
                                {


                                    break;
                                }
                            case "endrep":
                                {
                                    break;
                                }
                        }
                    }

                    switch(parts[1])
                    {
                        case "ifdef":
                            {
                                _brs.Push(_br);

                                _br = _br & _defines.ContainsKey(parts[2]);

                                break;
                            }
                        case "ifndef":
                            {
                                _brs.Push(_br);

                                _br = _br & !_defines.ContainsKey(parts[2]);

                                break;
                            }
                        case "else":
                            {
                                _br = !_br & _brs.Peek();
                                break;
                            }
                        case "endif":
                            {
                                _br = _brs.Pop();

                                break;
                            }
                        default:
                            {
                                break;
                            }
                    }

                    parts.Clear();
                }
            }

           if (_br)
                _parts.Add(parts);          
        }

    }
}
