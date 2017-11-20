using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Golf
{
    class Hole
    {
        int _length;
        int _par;                    //100-229m = par 3   230-429 = par 4  430-500 = par 5
        int _swingsAllowed;
        int _levelOfDifficulty;
        int _decimetersToFlag;
        public List<string> SwingHistory = new List<string>();

        public int Length { get => _length; set => _length = value; }
        public int Par { get => _par; set => _par = value; }
        public int SwingsAllowed { get => _swingsAllowed; set => _swingsAllowed = value; }
        public int LevelOfDifficulty { get => _levelOfDifficulty; set => _levelOfDifficulty = value; }
        public int DecimetersToFlag { get => _decimetersToFlag; set => _decimetersToFlag = value; }

        public void StartSwinging()
        {
            int swingsLeft = SwingsAllowed;
            int swingCounter = 0;
            int swingAngle = 0;
            int swingVelocity = 0;
            double swingDistance = 0;
            bool notGivingUp = true;
            bool tooFarFromFlag = false;
            this.DecimetersToFlag = Length * 10;
            while (notGivingUp && !tooFarFromFlag && swingsLeft > 0 && DecimetersToFlag > 1)
            {
                swingCounter++;
                Console.WriteLine("Swing: " + swingCounter + "\t Distance to flag: " + DecimetersToFlag / 10.0 + " meters.");
                Console.Write("Input your swing angle (or input negative value to give up): ");
                swingAngle = Convert.ToInt32(this.GetNumber());

                if (swingAngle < 0) // user wants to quit the hole and gave a negative input  
                {               
                    notGivingUp = false;
                    Console.WriteLine("Giving up eh?");
                    SwingHistory.Add("Giving up.");
                }
                else                // user swings the ball forward
                {                           
                    Console.Write("Input your swing speed in meters/second:(1-100) ");
                    swingVelocity = Convert.ToInt32(this.GetNumber());
                    swingDistance = this.DistanceCalculator(swingVelocity, swingAngle);
                    Console.WriteLine("Your swing took your ball forward " + swingDistance + " meters!");
                    this.SetDecimetersToFlag((int)Math.Round(-10 * swingDistance));
                    if ((this.DecimetersToFlag / 10) > Length)
                    {
                        tooFarFromFlag = true;
                    }
                    SwingHistory.Add(swingDistance.ToString() + " m");
                    swingsLeft--;
                }
            }
            if (!notGivingUp)
            {
                Console.WriteLine("No shame in giving up... Game over!");
            }
            else if (tooFarFromFlag)
            {
                Console.WriteLine("Your swing took the ball outside the course and is lost. Game over!");
            }
            else if (this.DecimetersToFlag > 1)
            {
                Console.WriteLine("Swing limit reached. Game over!");
            }
            else if (notGivingUp)
            {
                Console.WriteLine("And the ball rolls into the cup! Awesome!\nYou made it in " + swingCounter + " swings on a"
                        + " par " + Par + " hole.");
            }
            this.PrintHoleHistory();

        }
        public double DistanceCalculator(int swingSpeed, int swingAngle)
        {
            float gravity = 9.8f;
            return Math.Round(10 * Math.Pow(swingSpeed, 2) / gravity * Math.Sin(2 * ((Math.PI / 180) * swingAngle))) / 10.0;
        }

        public void SetDecimetersToFlag(int decimetersToFlag)
        {
            this.DecimetersToFlag += decimetersToFlag;
            if (this.DecimetersToFlag < 0)
            {                                             // if ball goes past the flag the distance will be negative.
                this.DecimetersToFlag *= -1;              // then we need to change it to positive
            }
        }

        public void GenerateHole()
        {
            Random Rnd = new Random();
            this.Length = Rnd.Next(400)+100;
            this.SetPar();
            this.SetSwingsAllowed();
        }
        public void PrintHoleHistory()
        {
            Console.WriteLine("Hole history:\nDistance to flag: " + (DecimetersToFlag / 10) + " m\t Par: " + Par);
            for (int i = 0; i < SwingHistory.Count(); i++)
            {
                Console.WriteLine("Swing " + (i + 1) + ": " + SwingHistory[i] + "\t");
            }
        }

        public void GetDifficultyFromConsole()
        {
            Console.Write("Enter your choice of difficulty. 0=Insane, 1=Very Tough, 2=Tough, 3=Normal, 4=Easy, 5=Too easy : ");
            this.LevelOfDifficulty = Convert.ToInt32(this.GetNumber());
        }

        public void SetSwingsAllowed()
        {
            this.SwingsAllowed = this.Par + this.LevelOfDifficulty;
        }
        public void SetPar()
        {
            if(this.Length > 429)
            {
                this.Par = 5;
            }
            else if(this.Length > 229)
            {
                this.Par = 4;
            }
            else
            {
                this.Par = 3;
            }
        }

        public double GetNumber()
        {
            double num;
            while (true)
            {
                try
                {
                    num = Convert.ToDouble(Console.ReadLine());
                    break;
                }
                catch (Exception)
                {
                    Console.WriteLine("Input error. Try again.");
                }
            }
            return num;
        }
    }
}
