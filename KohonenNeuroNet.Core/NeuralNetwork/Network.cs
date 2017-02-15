using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KohonenNeuroNet.Core.NeuralNetwork
{
    /// <summary>
    /// Нейронная сеть.
    /// </summary>
    public class Network
    {
        public int Inputs { get; set; }
        public List<Neuron> Neurons { get; set; }

        public Network(int inputs_, int neurons_)
        {
            Neurons = new List<Neuron>();
            Inputs = inputs_;
            for (int i = 0; i < neurons_; i++)
            {
                Neuron neuron = new Neuron(i, inputs_);
                Neurons.Add(neuron);
            }
        }

        private int Test(double[] InputVector)
        {
            double MinDistance = EuclideanDistance(Neurons[0], InputVector);
            int BMUIndex = 0;
            for (int i = 1; i < Neurons.Count; i++)
            {
                double tmp_ED = EuclideanDistance(Neurons[i], InputVector);
                if (tmp_ED < MinDistance)
                {
                    BMUIndex = i;
                    MinDistance = tmp_ED;
                }
            }
            return BMUIndex;
        }

        private void Study(double[][] InputVector)
        {
            int c;
            for (int k = 0; k < 6; k++) // цикл, в котором предъявляем сети входные вектора - InputVector
            {
                double MinDistance = EuclideanDistance(Neurons[0], InputVector[k]);
                int BMUIndex = 0;
                for (int i = 1; i < Neurons.Count; i++)
                {
                    double tmp_ED = EuclideanDistance(Neurons[i], InputVector[k]); // Находим Евклидово расстояние между i-ым нейроном и k-ым входным  вектором
                    if (tmp_ED < MinDistance) // Eсли Евклидово расстояние минимально, то это нейрон-победитель
                    {
                        BMUIndex = i; // Индекс нейрона-победителя
                        MinDistance = tmp_ED;
                    }
                }

                for (int i = 0; i < Neurons.Count; i++)
                {
                    for (int g = 0; g < InputVector[k].Length; g++)
                    {
                        double hfunc = hc(k, Neurons[BMUIndex].weights[g], Neurons[i].weights[g]);
                        double normfunc = normLearningRate(k);
                        //neurons[i].weights[g] = neurons[i].weights[g] + hfunc * normfunc * (InputVector[k][g] - neurons[i].weights[g]);
                        Neurons[i].weights[g] = Neurons[i].weights[g] + hfunc * normfunc * (InputVector[i][g] - Neurons[i].weights[g]); // Вроде так работает
                        if (i > 0 && g > 282)
                            c = 0;
                    }
                }
                double Error = EuclideanDistance(Neurons[BMUIndex], InputVector[k]);
                for (int y = 0; y < 6; y++)
                {
                    //textBox1.Text += "Евклидово расстояние " + y + "-го нейрона между " + y + "-м входным вектором на " + k + "-ой итерации: " + EuclideanDistance(neurons[y], InputVector[y]) + Environment.NewLine;
                }
                //textBox1.Text += Environment.NewLine;
            }
        }

        private double hc(int k, double winnerCoordinate, double Coordinate)
        {
            double dist = Distance(winnerCoordinate, Coordinate);
            //double s = sigma(k);
            return Math.Exp(-dist / 2 * Math.Pow(sigma(k), 2));
        }

        private double sigma(int k)
        {
            //return -0.01 * k + 2;
            return 1 * Math.Exp(-k / 5);

            //double nf = 1000 / Math.Log(2025);
            //return Math.Exp(-k / nf) * 2025;
        }

        private double normLearningRate(int k)
        {
            return 0.1 * Math.Exp(-k / 1000);
        }

        private double EuclideanDistance(Neuron neuron, double[] InputVector)
        {
            double Sum = 0;
            for (int i = 0; i < InputVector.Length; i++)
            {
                Sum += Math.Pow((InputVector[i] - neuron.weights[i]), 2);
            }
            return Math.Sqrt(Sum);
        }

        private double Distance(double winnerCoordinate, double Coordinate)
        {
            return Math.Sqrt(Math.Pow((winnerCoordinate - Coordinate), 2));
        }
    }
}
