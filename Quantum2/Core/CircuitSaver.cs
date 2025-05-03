using System;
using System.Xml;

namespace Quantum2.Core
{
    public static class CircuitSaver
    {
        public static void SaveToXMLFile(string file, Circuit circuit)
        {
            SaveToXML(circuit).Save(file);
        }

        public static XmlDocument SaveToXML(Circuit circuit)
        {
            XmlDocument xmlDocument = new XmlDocument();

            XmlNode xmlNodeCircuit = xmlDocument.CreateElement("Circuit");

            XmlNode xmlNodeQRegisters = xmlDocument.CreateElement("QRegisters");
            XmlNode xmlNodeInstructions = xmlDocument.CreateElement("Instructions");
            XmlNode xmlNodeMeasurmentsQubits = xmlDocument.CreateElement("Measurments_Qubits");
            XmlNode xmlNodeResults = xmlDocument.CreateElement("Results");

            for(int i =0; i < circuit.QRegisters.Length;i++)
            {
                XmlNode xmlNodeQRegister = xmlDocument.CreateElement("QRegister");

                XmlNode xmlNodeN = xmlDocument.CreateElement("N");
                XmlNode xmlNodeQubits = xmlDocument.CreateElement("Qubits");

                XmlAttribute xmlNodeNAttribute = xmlDocument.CreateAttribute("Value");

                xmlNodeNAttribute.Value = circuit.QRegisters[i].N.ToString();

                xmlNodeN.Attributes.Append(xmlNodeNAttribute);

                for(int j = 0; j < circuit.QRegisters[i].Qubits.Length;j++)
                {
                    XmlNode xmlNodeQubit = xmlDocument.CreateElement("Qubit");

                    XmlNode xmlNodeQubitAlpha = xmlDocument.CreateElement("Alpha");
                    XmlNode xmlNodeQubitBeta = xmlDocument.CreateElement("Beta");

                    XmlAttribute xmlNodeAttributeAlpha = xmlDocument.CreateAttribute("Value");
                    XmlAttribute xmlNodeAttributeBeta = xmlDocument.CreateAttribute("Value");

                    xmlNodeAttributeAlpha.Value = ComplexExtension.TS(circuit.QRegisters[i].Qubits[j].Alpha);
                    xmlNodeAttributeBeta.Value = ComplexExtension.TS(circuit.QRegisters[i].Qubits[j].Beta);

                    xmlNodeQubitAlpha.Attributes.Append(xmlNodeAttributeAlpha);
                    xmlNodeQubitBeta.Attributes.Append(xmlNodeAttributeBeta);

                    xmlNodeQubit.AppendChild(xmlNodeQubitAlpha);
                    xmlNodeQubit.AppendChild(xmlNodeQubitBeta);

                    xmlNodeQubits.AppendChild(xmlNodeQubit);
                }

                xmlNodeQRegister.AppendChild(xmlNodeN);
                xmlNodeQRegister.AppendChild(xmlNodeQubits);

                xmlNodeQRegisters.AppendChild(xmlNodeQRegister);
            }

            for(int i = 0; i < circuit.Instructions.Length;i++)
            {
                XmlNode xmlNodeGroupInstructions = xmlDocument.CreateElement("GroupInstructions");

                for(int j = 0;j < circuit.Instructions[i].Length;j++)
                {
                    XmlNode xmlNodeInstruction = xmlDocument.CreateElement("Instruction");

                    XmlNode xmlNodeNumbers = xmlDocument.CreateElement("Numbers");
                    XmlNode xmlNodeGate = xmlDocument.CreateElement("Gate");

                    for(int k = 0; k < circuit.Instructions[i][j]._numbers.Length;k++)
                    {
                        XmlNode xmlNodeNumber = xmlDocument.CreateElement("Number");

                        XmlAttribute xmlNodeAttributeNumber = xmlDocument.CreateAttribute("Value");

                        xmlNodeAttributeNumber.Value = circuit.Instructions[i][j]._numbers[k].ToString();

                        xmlNodeNumber.Attributes.Append(xmlNodeAttributeNumber);

                        xmlNodeNumbers.AppendChild(xmlNodeNumber);
                    }

                    XmlNode xmlNodeNameGate = xmlDocument.CreateElement("Name");
                    XmlNode xmlNodeArgsGate = xmlDocument.CreateElement("Args");

                    XmlAttribute xmlNodeAttributeNameGate = xmlDocument.CreateAttribute("Value");

                    xmlNodeAttributeNameGate.Value = circuit.Instructions[i][j]._gate.Name;

                    xmlNodeNameGate.Attributes.Append(xmlNodeAttributeNameGate);

                    for(int k = 0; k < circuit.Instructions[i][j]._gate.Args.Length;k++)
                    {
                        XmlNode xmlNodeArgGate = xmlDocument.CreateElement("Arg");

                        XmlAttribute xmlNodeAttributeArgGate = xmlDocument.CreateAttribute("Value");

                        xmlNodeAttributeArgGate.Value = circuit.Instructions[i][j]._gate.Args[k].ToString();

                        xmlNodeArgGate.Attributes.Append(xmlNodeAttributeArgGate);

                        xmlNodeArgsGate.AppendChild(xmlNodeArgGate);
                    }

                    xmlNodeGate.AppendChild(xmlNodeNameGate);
                    xmlNodeGate.AppendChild(xmlNodeArgsGate);

                    xmlNodeInstruction.AppendChild(xmlNodeNumbers);
                    xmlNodeInstruction.AppendChild(xmlNodeGate);

                    xmlNodeGroupInstructions.AppendChild(xmlNodeInstruction);
                }

                xmlNodeInstructions.AppendChild(xmlNodeGroupInstructions);
            }

            for(int i = 0;i < circuit.MeasuredQubits.Length;i++)
            {
                XmlNode xmlNodeMeasuredQubit = xmlDocument.CreateElement("MeasuredQubit");

                XmlAttribute xmlNodeAttributeMeasuredQubit = xmlDocument.CreateAttribute("Value");

                xmlNodeAttributeMeasuredQubit.Value = circuit.MeasuredQubits[i].ToString();

                xmlNodeMeasuredQubit.Attributes.Append(xmlNodeAttributeMeasuredQubit);

                xmlNodeMeasurmentsQubits.AppendChild(xmlNodeMeasuredQubit);
            }

            XmlNode xmlNodeStates = xmlDocument.CreateElement("States");
            XmlNode xmlNodeMeasuredQubits = xmlDocument.CreateElement("Measured_Qubits");

            for(int i = 0; i < circuit.States.M;i++)
            {
                XmlNode xmlNodeState = xmlDocument.CreateElement("State");

                XmlAttribute xmlNodeAttributeState = xmlDocument.CreateAttribute("Value");

                xmlNodeAttributeState.Value = ComplexExtension.TS( circuit.States.Get(i, 0));

                xmlNodeState.Attributes.Append(xmlNodeAttributeState);

                xmlNodeStates.AppendChild(xmlNodeState);
            }

            foreach (var mq in circuit.Measure.MBits)
            {
                XmlNode xmlNodeMeasuredQubit = xmlDocument.CreateElement("Measured_Qubit");

                XmlNode xmlNodeNumberMeasuredQubit = xmlDocument.CreateElement("Number");
                XmlNode xmlNodeValueMeasuredQubit = xmlDocument.CreateElement("Value");

                XmlAttribute xmlNodeAttributeNumberMeasuredQubit = xmlDocument.CreateAttribute("Value");
                XmlAttribute xmlNodeAttributeValueMeasuredQubit = xmlDocument.CreateAttribute("Value");

                xmlNodeAttributeNumberMeasuredQubit.Value = mq.Key.ToString();
                xmlNodeAttributeValueMeasuredQubit.Value = mq.Value.ToString();

                xmlNodeNumberMeasuredQubit.Attributes.Append(xmlNodeAttributeNumberMeasuredQubit);
                xmlNodeValueMeasuredQubit.Attributes.Append(xmlNodeAttributeValueMeasuredQubit);

                xmlNodeMeasuredQubit.AppendChild(xmlNodeNumberMeasuredQubit);
                xmlNodeMeasuredQubit.AppendChild(xmlNodeValueMeasuredQubit);

                xmlNodeMeasuredQubits.AppendChild(xmlNodeMeasuredQubit);
            }

            xmlNodeResults.AppendChild(xmlNodeStates);
            xmlNodeResults.AppendChild(xmlNodeMeasuredQubits);

            xmlNodeCircuit.AppendChild(xmlNodeQRegisters);
            xmlNodeCircuit.AppendChild(xmlNodeInstructions);
            xmlNodeCircuit.AppendChild(xmlNodeMeasurmentsQubits);
            xmlNodeCircuit.AppendChild(xmlNodeResults);

            xmlDocument.AppendChild(xmlNodeCircuit);

            return xmlDocument;
        }
    }
}
