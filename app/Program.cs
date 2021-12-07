// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
using System;
using System.Collections;
class AdventOfCode
{
    static void Main()
    {
        Console.WriteLine("Hello, Advent of Code!");
        bool isSuccess = false;
        var adventClass = new AdventOfCode();      

        //Day 1
        //isSuccess = adventClass.adventOne();

        //Day 2
        //isSuccess = adventClass.adventTwoPartOne();
        //isSuccess = adventClass.adventTwoPartTwo();

        //Day 3
        //isSuccess = adventClass.adventThreePartOne();
        //isSuccess = adventClass.adventThreePartTwo();

        //Day 6
        //isSuccess = adventClass.adventSixPartOne();
        isSuccess = adventClass.adventSixPartTwo();

    }

    private bool adventOne()
    {
        int counter = 0;
        int position = 0;
        int previous = -1;
        int current = -1;
        bool isValid = false;
        LinkedList<int> values = new LinkedList<int>();

        foreach (string line in System.IO.File.ReadLines(@".\texts\test.txt"))
        {  
            position++;
            if(position>3){
                isValid=true;
            }

            int integerLine = int.Parse(line);
            values.AddFirst(integerLine);
            
            if (isValid){
                current = values.First.Value + values.First.Next.Value + values.First.Next.Next.Value ;
                previous = values.First.Next.Value + values.First.Next.Next.Value + values.First.Next.Next.Next.Value;
                if (current > previous){
                    counter++;
                }
            }
        }   

        System.Console.WriteLine("Value: {0}", counter);
        return true;
    }
    
    private bool adventTwoPartOne()
    {
        int vertical = 0;
        int horizontal = 0;
        int final = 0;

        foreach (string line in System.IO.File.ReadLines(@".\texts\day2.txt")){
            string[] words = line.Split(' ');
            if (words[0] == "forward"){
                horizontal += int.Parse(words[1]);
            } else if (words[0] == "down"){
                vertical += int.Parse(words[1]);
            } else if (words[0] == "up"){
                vertical -= int.Parse(words[1]);
            }
        }

        final = vertical * horizontal;
        System.Console.WriteLine("Value: {0}", final);
        return true;
    }
    
    private bool adventTwoPartTwo() 
    {
        int aim = 0;
        int depth = 0;
        int horizontal = 0;
        int final = 0;

        foreach (string line in System.IO.File.ReadLines(@".\texts\day2.txt")){
            string[] words = line.Split(' ');
            if (words[0] == "forward"){
                horizontal += int.Parse(words[1]);
                depth += int.Parse(words[1]) * aim;
            } else if (words[0] == "down"){
                aim += int.Parse(words[1]);
            } else if (words[0] == "up"){
                aim -= int.Parse(words[1]);
            }
        }

        final = depth * horizontal;
        System.Console.WriteLine("Value: {0}", final);
        return true;
    }

    private bool adventThreePartOne() 
    {
        double gamma = 0;
        double epsilon = 0;
        int[] digitCount = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        int[] finalDigits = new int[12];

        foreach (string line in System.IO.File.ReadLines(@".\texts\day3.txt")){
            char[] digitsInArray = new char[12];
            using (StringReader sr = new StringReader(line))
            {
                // Read 12 characters from the string into the array.
                sr.Read(digitsInArray, 0, 12);


                for (int i = 0; i < 12; i++){
                    //convert char to int?
                    double thisDigit = Char.GetNumericValue(digitsInArray[i]);
                    if (thisDigit == 0){
                        digitCount[i]--;
                    } else if (thisDigit == 1){
                        digitCount[i]++;
                    }
                }

            }
        }

        //Create Final Binary Digits from Values array
        int position = 0;
            foreach (int i in digitCount){
                if (i > 0){
                    finalDigits[position] = 1;
                }
                else {
                    finalDigits[position] = 0;
                }
                position++;
            }
        
        for (int i = 11; i >= 0; i--){
            int power = 11 -  i;
            if (finalDigits[i] == 1){
                gamma += Math.Pow(2, power);
            } else {
                epsilon += Math.Pow(2, power);
            }
        }

        double powerConsumption = gamma * epsilon;

        Console.WriteLine("Value: {0}", powerConsumption);

        // Console.WriteLine("Value: ");
        // foreach (int i in finalDigits){
        //     Console.Write("{0} ", i);
        // }
        
        return true;
    }

    private bool adventThreePartTwo() 
    {
        int lifeSupportRating;
        int oxyGenRating;
        int scrubberRating;

        foreach (string line in System.IO.File.ReadLines(@".\texts\day3.txt")){
            char[] digitsInArray = new char[12];
            using (StringReader sr = new StringReader(line))
            {
                // Read 12 characters from the string into the array.
                sr.Read(digitsInArray, 0, 12);
            }

            foreach (int i in digitsInArray){
                
            }
        }



        return true;
    }

    private bool adventSixPartOne(){
        int totalDays = 80;
        List<int> fishList = new List<int>();
        int newFish = 0;

        string[] startingFish = File.ReadAllLines(@".\texts\day6.txt");
        string[] stringOfFish = startingFish[0].Split(',');
        foreach (string age in stringOfFish){
            fishList.Add(int.Parse(age));
        }

        Console.WriteLine("Value: {0}", fishList.Count);

        for (int i = 0; i < totalDays; i++){
            for(int j = 0; j < fishList.Count; j++){
                if (fishList[j] == 0){
                    fishList[j] = 6;
                    newFish++;
                } else {
                    fishList[j]--;
                }
            }
            for (int j = 0; j < newFish; j++){
                fishList.Add(8);
            }
            newFish = 0;
        }

        Console.WriteLine("Value: {0}", fishList.Count);

        //print list of fish
        // foreach (int age in fishList){
        //     Console.WriteLine("{0},", age);
        // }

        return true;
    } 

    private bool adventSixPartTwo(){

        int totalDays = 256;
        long totalFish = 0;

        List<int> fishList = new List<int>();
        List<int> fishList2 = new List<int>();
        List<int> fishList3 = new List<int>();
        List<int> fishList4 = new List<int>();
        List<int> fishList5 = new List<int>();

        int newFish = 0;

        string[] startingFish = File.ReadAllLines(@".\texts\day6.txt");
        string[] stringOfFish = startingFish[0].Split(',');
        foreach (string age in stringOfFish){
            fishList.Add(int.Parse(age));
        }

        Console.WriteLine("Value: {0}", fishList.Count);

        for (int i = 0; i < totalDays; i++){
            for(int j = 0; j < fishList.Count; j++){
                if (fishList[j] == 0){
                    fishList[j] = 6;
                    newFish++;
                } else {
                    fishList[j]--;
                }
            }
            for(int j = 0; j < fishList2.Count; j++){
                if (fishList2[j] == 0){
                    fishList2[j] = 6;
                    newFish++;
                } else {
                    fishList2[j]--;
                }
            }
            for(int j = 0; j < fishList3.Count; j++){
                if (fishList3[j] == 0){
                    fishList3[j] = 6;
                    newFish++;
                } else {
                    fishList3[j]--;
                }
            }
            for(int j = 0; j < fishList4.Count; j++){
                if (fishList4[j] == 0){
                    fishList4[j] = 6;
                    newFish++;
                } else {
                    fishList4[j]--;
                }`
            }
            for(int j = 0; j < fishList5.Count; j++){
                if (fishList5[j] == 0){
                    fishList5[j] = 6;
                    newFish++;
                } else {
                    fishList5[j]--;
                }
            }


            for (int j = 0; j < newFish; j++){
                if (fishList.Count < (int.MaxValue/2)){
                    fishList.Add(8);
                }   else if (fishList2.Count < (int.MaxValue/2)) {
                    fishList2.Add(8);
                } else if (fishList3.Count < (int.MaxValue/2)){
                    fishList3.Add(8);
                } else if (fishList4.Count < (int.MaxValue/2)){
                    fishList4.Add(8);
                } else if (fishList5.Count < (int.MaxValue/2)){
                    fishList5.Add(8);
                }
                
            }
            newFish = 0;
        }

        Console.WriteLine("Value: {0}", fishList.Count + fishList2.Count + fishList3.Count + fishList4.Count + fishList5.Count);

        return true;

    }
}
