using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Quantum2.View
{
    class GraphOutput
    {
        public Panel _panel;
        public Button _button;
        public bool _active;

        public void Clear()
        {
            _panel.Dispose();
            _button.Dispose();
        }
    }
    public partial class GateControl : UserControl
    {
        private static GE[,] _gElements;
        private static List<GateControl> _gateControls;

        public static Control NoScrollParentButton { get; set; }

        public static Control ScrollParentButton { get; set; }

        private List<List<Panel>> _rectDotsRW;

        private Rectangle _screenRectangle;

        private bool _active;
        private string _name;

        private int _posX = -1;
        private int _posY = -1;

        private GraphOutput[] _graphOutputs;
        private Point _downPoint;
        private int[] _outputs;
        private int _numberOutput;

        private ArgsGateForm _argsGateForm;

        public static GE[,] GElements
        {
            get
            {
                return _gElements;
            }
        }

        static GateControl()
        {
            _gElements = new GE[0, 0];

            _gateControls = new List<GateControl>();
        }

        public GateControl(List<List<Panel>> rectDotsRW, string name,int countOutputs, int countArgs)
        {
            InitializeComponent();

            _rectDotsRW = rectDotsRW;

            _screenRectangle = new Rectangle(Location, Size);

            _active = false;

            _name = name;

            GateButton.Text = _name;

            _graphOutputs = new GraphOutput[countOutputs];
            _outputs = new int[countOutputs];

            _argsGateForm = new ArgsGateForm(countArgs);
        }

        public static void SetFieldSizeOfQuantumCircuit(int countVerticals,int countRegisters)
        {
            int x = _gElements.GetLength(0);
            int y = _gElements.GetLength(1);

            ResizeArray<GE>(ref _gElements, countVerticals, countRegisters);

            for(int i = y; i < countRegisters; i++)
            {
                for(int j = 0; j < countVerticals;j++)
                {
                    _gElements[j, i] = new GE();
                }
            }

            for(int i = x; i < countVerticals; i++)
            {
                for(int j = 0; j < countRegisters;j++)
                {
                    _gElements[i, j] = new GE();
                }
            }
        }

        /*public static void ResizeArray<T>(ref T[,] original, int newCoNum, int newRoNum)
        {
            var newArray = new T[newCoNum, newRoNum];
            int columnCount = original.GetLength(1);
            int columnCount2 = newRoNum;
            int columns = original.GetUpperBound(0);
            for (int co = 0; co <= columns; co++)
                Array.Copy(original, co * columnCount, newArray, co * columnCount2, columnCount);
            original = newArray;
        }*/

        public static void Clear()
        {
            for(int x = 0; x < _gElements.GetLength(0);x++)
            {
                for(int y = 0; y < _gElements.GetLength(1);y++)
                {
                    _gElements[x, y]._name = "";
                    _gElements[x, y]._outputs = new int[0];
                    _gElements[x, y]._args = new double[0];
                }
            }

            for(int i =0; i < _gateControls.Count;i++)
            {
                _gateControls[i].Dispose(true);
            }

            _gateControls.Clear();
        }

        public static void ClearLastGate()
        {
            if (_gateControls.Count > 0)
            {
                _gElements[_gateControls[_gateControls.Count - 1]._posX, _gateControls[_gateControls.Count - 1]._posY]._name = "";
                _gElements[_gateControls[_gateControls.Count - 1]._posX, _gateControls[_gateControls.Count - 1]._posY]._outputs = new int[0];
                _gElements[_gateControls[_gateControls.Count - 1]._posX, _gateControls[_gateControls.Count - 1]._posY]._args = new double[0];

                _gateControls[_gateControls.Count - 1].Dispose();
                _gateControls.RemoveAt(_gateControls.Count - 1);
            }
        }

        public static void ResizeArray<T>(ref T[,] array, int size1, int size2)
        {
            T[,] new_array = new T[size1, size2];
            size1 = Math.Min(array.GetLength(0), size1);
            size2 = Math.Min(array.GetLength(1), size2);
            for (int i = 0; i < size1; i++)
            {
                for (int j = 0; j < size2; j++) new_array[i, j] = array[i, j];
            }
            array = new_array;
        }

        public void SetOutputs(int[] outputs)
        {
            CreateAndSetOutputs(outputs);
        }

        public void SetArgs(double[] args)
        {
            _argsGateForm.SetArgs(args);
        }

        public void SwitchActive()
        {
            _active = !_active;

            if (_active)
            {
                Controller.SubUpdate(MouseMovementGate);

                UnSet();
            }
            else
            {
                Controller.UnSubUpdate(MouseMovementGate);

                _screenRectangle = Parent.RectangleToScreen(Bounds);

                for (int y = 0; y < _rectDotsRW.Count; y++)
                {
                    for (int x = 0; x < _rectDotsRW[y].Count; x++)
                    {

                        if (_rectDotsRW[y][x].Parent.RectangleToScreen(_rectDotsRW[y][x].Bounds).IntersectsWith(_screenRectangle))
                        {
                            Set(x, y);

                            StartOutputs();

                            return;
                        }
                    }
                }
            }
        }

        public void Set(int x,int y)
        {
            Point location = Parent.PointToClient( _rectDotsRW[y][x].Parent.PointToScreen(_rectDotsRW[y][x].Location));

            location.X -= (Size.Width / 4);
            location.Y -= (Size.Height / 4);

            _downPoint = location;

            _downPoint.X += 10;
            _downPoint.Y += 10;

            Location = location;

            _gElements[x, y]._name = _name;
            _gElements[x, y]._args = _argsGateForm.Args;

            _posX = x;
            _posY = y;

            _gateControls.Add(this);
        }

        public void SetOutput(int number, int y)
        {
            Size size = _graphOutputs[number]._panel.Size;
            Point position = _graphOutputs[number]._panel.Location;

            Point positionClinButton = _graphOutputs[number]._button.Location;

            Point target = _graphOutputs[number]._panel.Parent.PointToClient(_rectDotsRW[y][_posX].PointToScreen( _rectDotsRW[y][_posX].Location));

            if (target.Y < _downPoint.Y)
            {
                size.Height = _downPoint.Y - target.Y;

                position.Y = _downPoint.Y - size.Height - 5;
                positionClinButton.Y = position.Y;

            }
            else
            {

                size.Height = target.Y - _downPoint.Y - 5;

                position.Y = _downPoint.Y + 17;
                positionClinButton.Y = size.Height + 150;
            }

            _graphOutputs[number]._panel.Location = position;
            _graphOutputs[number]._panel.Size = size;

            _graphOutputs[number]._button.Location = positionClinButton;

            _gElements[_posX, _posY]._outputs[number] = y;
        }

        public void CreateAndSetOutputs(int[] outputs)
        {
            _gElements[_posX, _posY]._outputs = new int[_outputs.Length];

            for(; _numberOutput < outputs.Length;_numberOutput++)
            {
                CreateOutput();

                SetOutput(_numberOutput, outputs[_numberOutput]);
            }
        }

        public void UnSet()
        {
            if ((_posX > -1) && (_posY > -1))
            {
                _gElements[_posX, _posY]._name = "";
                _gElements[_posX, _posY]._args = new double[0];
                _gElements[_posX, _posY]._outputs = new int[0];

                _posX = -1;
                _posY = -1;

                _gateControls.Remove(this);
            }

            for(int i = 0; i < _graphOutputs.Length;i++)
            {
                if (_graphOutputs[i] != null)
                {
                    _graphOutputs[i]._active = false;
                    _graphOutputs[i]._panel.Dispose();
                    _graphOutputs[i]._button.Dispose();
                }
            }
        }

        private void StartOutputs()
        {
            if (_outputs.Length <= 0)
                return;

            _gElements[_posX, _posY]._outputs = new int[_outputs.Length];

            _numberOutput = 0;

            CreateOutput();

            _graphOutputs[_numberOutput]._active = true;

            Controller.SubUpdate(MouseMovementOutput);
        }

        private void CreateOutput()
        {
            _graphOutputs[_numberOutput] = new GraphOutput();

            _graphOutputs[_numberOutput]._panel = new Panel();
            _graphOutputs[_numberOutput]._panel.Size = new Size(10, 100);
            _graphOutputs[_numberOutput]._panel.Location = _downPoint;
            _graphOutputs[_numberOutput]._panel.BackColor = Color.Red;

            _graphOutputs[_numberOutput]._button = new Button();
            _graphOutputs[_numberOutput]._button.Location = new Point(_downPoint.X - 5, _downPoint.Y);
            _graphOutputs[_numberOutput]._button.Size = new Size(20, 20);

            int k = _numberOutput;

            _graphOutputs[_numberOutput]._button.MouseClick += delegate (object obj, MouseEventArgs mouseEventArgs) {
                _graphOutputs[k]._active = !_graphOutputs[k]._active;

                if (_graphOutputs[k]._active)
                {
                    Controller.SubUpdate(MouseMovementOutput);
                }
                else
                {
                    Controller.UnSubUpdate(MouseMovementOutput);

                    _screenRectangle = Parent.RectangleToScreen(_graphOutputs[_numberOutput]._button.Bounds);

                    for (int y = 0; y < _rectDotsRW.Count; y++)
                    {
                        for (int x = 0; x < _rectDotsRW[y].Count; x++)
                        {

                            if (_rectDotsRW[y][x].Parent.RectangleToScreen(_rectDotsRW[y][x].Bounds).IntersectsWith(_screenRectangle))
                            {
                                SetOutput(k, y);
                            }
                        }
                    }
                }
            };

            Parent.Controls.Add(_graphOutputs[_numberOutput]._panel);
            Parent.Controls.Add(_graphOutputs[_numberOutput]._button);

            _graphOutputs[_numberOutput]._panel.BringToFront();
            _graphOutputs[_numberOutput]._button.BringToFront();
        }

        private void MouseMovementOutput(object obj, EventArgs e)
        {
            Point cursor = Parent.PointToClient(MousePosition);
            Point position = _downPoint;
            Point positionClinButton = _downPoint;

            positionClinButton.X -= 5;
            positionClinButton.Y = cursor.Y - 10;

            Size size = _graphOutputs[_numberOutput]._panel.Size;

            if (cursor.Y < _downPoint.Y)
            {
                size.Height = _downPoint.Y - cursor.Y;

                position.Y = _downPoint.Y - size.Height - 10;
                //positionClinButton.Y = position.Y;

            }
            else
            {

                size.Height = cursor.Y - _downPoint.Y - 10;

                position.Y = _downPoint.Y + 17;
                //positionClinButton.Y = size.Height + 150;
            }

            _graphOutputs[_numberOutput]._panel.Location = position;

            _graphOutputs[_numberOutput]._panel.Size = size;

            _graphOutputs[_numberOutput]._button.Location = positionClinButton;
        }

        private void MouseMovementGate(object obj, EventArgs e)
        {

            Point location = Parent.PointToClient(MousePosition);

            location.X -= (Size.Width / 2);
            location.Y -= (Size.Height / 2);

            Location = location;
        }

        private void GateButton_Click(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                SwitchActive();
            }
            else if(e.Button == MouseButtons.Right)
            {
                _argsGateForm.StartPosition = FormStartPosition.Manual;

                _argsGateForm.Location = new Point(Parent.Location.X + Parent.Size.Width- 250, Parent.Location.Y + Parent.Size.Width / 6);

                _argsGateForm.ShowDialog();
            }
        }
       
    }

    public class GE
    {
        public string _name;
        public int[] _outputs;
        public double[] _args;

        public GE()
        {
            _outputs = new int[0];
            _args = new double[0];
        }

        public override string ToString()
        {
            //блять исправить потом добавив остальное 
            return "NameGE: " + _name;
        }

    }
}
