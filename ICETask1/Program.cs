using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ICETask1
{
    public class InstituteInfo {
        public int noOfScripts;
        public int noOfQuestions;
        public int questionSubtotal;
        public int noOfLecturers;

        public int NoOfScripts
        {
            get => noOfScripts;
            set => noOfScripts = value < 0 ? value : 0;
        }


        public int NoOfQuestions
        {
            get => noOfQuestions;
            set => noOfQuestions = value >= 10 || value <= 1 ? value : 0;
        }

        public int QuestionSubtotal
        {
            get => questionSubtotal;
            set => questionSubtotal = value < 0 ? value : 0;
        }
        public int NoOfLecturers
        {
            get => noOfLecturers;
            set => noOfLecturers = value < 0 ? value : 0;
        }
    }
    public class Program {
        private int size = 0;
        private InstituteInfo iInfo = new InstituteInfo();

        static void Main(string[] args)
        {
            Program p = new Program();
            p.inputDetails();
            p.determineTime();
            Console.ReadLine();
        }

        public void inputDetails() {
            Console.WriteLine("Enter the amount of scripts to be marked.");
            iInfo.noOfScripts = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the nmuber of questions within the test.");
            iInfo.noOfQuestions = Convert.ToInt32(Console.ReadLine());
            while (size < iInfo.noOfQuestions)
            {
                Console.WriteLine("Enter the subtotal for question " + (size + 1));
                int subtotal = Convert.ToInt32(Console.ReadLine());
                iInfo.questionSubtotal += subtotal;
                size++;
            }
            Console.WriteLine("Enter the number of lecturers marking the script.");
            iInfo.noOfLecturers = Convert.ToInt32(Console.ReadLine());
        }

        public void determineTime() 
        {
            int allocatedScripts = iInfo.NoOfScripts / iInfo.NoOfLecturers;
            Console.WriteLine("Each lecturer is going to be signing " + allocatedScripts + " scripts");
            int seconds = 2 * iInfo.QuestionSubtotal;
            int minutes = (seconds / 60) * allocatedScripts;
            int remainingSeconds = seconds % 60;
            int hours = minutes / 60;
            int remainingMinutes = minutes % 60;
            if (remainingSeconds > 30 && remainingSeconds < 60)
                minutes++;
            Console.WriteLine("The time for each lecturer to finish marking their scripts is: " + (hours)
                + " hours and " + (remainingMinutes) + " minutes");
        }
    }
}
