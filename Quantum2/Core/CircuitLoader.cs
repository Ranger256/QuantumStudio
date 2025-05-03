using System;
using System.Numerics;
using System.Collections.Generic;
using System.Xml;

namespace Quantum2.Core
{
    public sealed class CircuitLoader
    {
        private List<QRegister> _qRegisters;
        private List<int> _measurmentQubits;

        private XmlNode _xmlNodeInstrs;

        public QRegister[] QRegisters
        {
            get
            {
                return _qRegisters.ToArray();
            }
        }

        public int[] MeasurmentQubits
        {
            get
            {
                return _measurmentQubits.ToArray();
            }
        }

        public CircuitLoader()
        {
            _qRegisters = new List<QRegister>();
            _measurmentQubits = new List<int>();
        }

        public void LoadFromXMLFile(string file)
        {
            XmlDocument xmlDocument = new XmlDocument();

            xmlDocument.Load(file);

            LoadFromXML(xmlDocument);
        }

        public void LoadFromXML(XmlDocument xmlDocument)
        {
            _qRegisters.Clear();
            _measurmentQubits.Clear();

            foreach(XmlNode circuit in xmlDocument)
            {
                if(circuit.Name == "Circuit")
                {
                    foreach(XmlNode ec in circuit)
                    {
                        switch(ec.Name)
                        {
                            case "QRegisters":
                                {
                                    LoadQRegistersFromXMLNode(ec);
                                    break;
                                }
                            case "Instructions":
                                {
                                    //LoadInstructionsFromXMLNode(ec);
                                    _xmlNodeInstrs = ec;
                                    break;
                                }
                            case "Measurments_Qubits":
                                {
                                    LoadMeasurmentsQubitsFromXMLNode(ec);
                                    break;
                                }
                            case "Results":
                                {
                                    LoadResultFromXmlNode(ec);
                                    break;
                                }
                        }
                    }
                }
            }
        }

        public void LoadInstructions()
        {
            LoadInstructionsFromXMLNode(_xmlNodeInstrs);
        }

        private void LoadQRegistersFromXMLNode(XmlNode xmlNode)
        {
            foreach(XmlNode xmlNodeQRegister in xmlNode)
            {
                if(xmlNodeQRegister.Name == "QRegister")
                {
                    QRegister qRegister = null;

                    foreach(XmlNode xmlNodeElementQRegister in xmlNodeQRegister)
                    {
                        if(xmlNodeElementQRegister.Name == "N")
                        {
                            qRegister = new QRegister(Convert.ToInt32( xmlNodeElementQRegister.Attributes[0].Value));
                        }
                        else if(xmlNodeElementQRegister.Name == "Qubits")
                        {
                            int indexQubit = 0;

                            foreach(XmlNode xmlNodeQubit in xmlNodeElementQRegister)
                            {
                                if(xmlNodeQubit.Name == "Qubit")
                                {
                                    Complex alpha = Complex.One;
                                    Complex beta = Complex.Zero;

                                    foreach (XmlNode xmlNodeElementQubit in xmlNodeQubit)
                                    {
                          
                                        if(xmlNodeElementQubit.Name == "Alpha")
                                        {
                                            alpha = ComplexExtension.Parse(xmlNodeElementQubit.Attributes[0].Value);
                                        }
                                        else if(xmlNodeElementQubit.Name == "Beta")
                                        {
                                            beta = ComplexExtension.Parse(xmlNodeElementQubit.Attributes[0].Value);
                                        }
                                    }

                                    qRegister.Qubits[indexQubit].Set(alpha, beta);

                                    indexQubit++;
                                }  
                            }
                        }
                    }

                    _qRegisters.Add(qRegister);
                }
            }
        }

        private void LoadInstructionsFromXMLNode(XmlNode xmlNode)
        {
            int group = 0;

            foreach(XmlNode xmlNodeGroupInstruction in xmlNode)
            {
                if(xmlNodeGroupInstruction.Name == "GroupInstructions")
                {

                    foreach(XmlNode xmlNodeInstruction in xmlNodeGroupInstruction)
                    {
                        int reg = 0;

                        List<int> outputs = new List<int>();

                        string name = "";

                        List<double> args = new List<double>();

                        foreach(XmlNode xmlNodeElementInstruction in xmlNodeInstruction)
                        {

                            if(xmlNodeElementInstruction.Name == "Numbers")
                            {
                                for(int i = 0; i < xmlNodeElementInstruction.ChildNodes.Count - 1;i++)
                                {
                                    outputs.Add(Convert.ToInt32( xmlNodeElementInstruction.ChildNodes[i].Attributes[0].Value));
                                }

                                reg = Convert.ToInt32(xmlNodeElementInstruction.ChildNodes[xmlNodeElementInstruction.ChildNodes.Count - 1].Attributes[0].Value);
                            }
                            else if(xmlNodeElementInstruction.Name == "Gate")
                            {
                                foreach(XmlNode xmlNodeElementGate in xmlNodeElementInstruction)
                                {
                                    if(xmlNodeElementGate.Name == "Name")
                                    {
                                        name = xmlNodeElementGate.Attributes[0].Value;
                                    }
                                    else if(xmlNodeElementGate.Name == "Args")
                                    {
                                        foreach (XmlNode xmlNodeArgGate in xmlNodeElementGate)
                                        {
                                            if (xmlNodeArgGate.Name == "Arg")
                                            {
                                                args.Add(Convert.ToDouble(xmlNodeArgGate.Attributes[0].Value));
                                            }
                                        }
                                    }
                                }
                            }
                        }

                        Controller.CreateAndSetGE(group, reg, name, outputs.ToArray(), args.ToArray());
                    }

                    group++;
                }
            }
        }

        private void LoadMeasurmentsQubitsFromXMLNode(XmlNode xmlNode)
        {
            foreach(XmlNode xmlNodeMeasurmentQubit in xmlNode)
            {
                if(xmlNodeMeasurmentQubit.Name == "MeasuredQubit" && xmlNodeMeasurmentQubit.Attributes.Count == 1)
                {
                    _measurmentQubits.Add(int.Parse( xmlNodeMeasurmentQubit.Attributes[0].Value));
                }
            }
        }

        private void LoadResultFromXmlNode(XmlNode xmlNode)
        {

        }
    }
}
