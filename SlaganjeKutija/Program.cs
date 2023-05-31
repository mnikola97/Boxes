using SlaganjeKutija;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;

class Program
{
    static void Main(string[] args)
    {
        List<Box> boxes = GenerateBoxes();
        
        //sort boxes by area then by height
        List<Box>sortedBoxes = boxes.OrderByDescending(b=>b.length*b.width).ThenByDescending(b=>b.height).ToList();

        Pile maxHeightStack = FindMaxHeightStack(sortedBoxes);

        Console.WriteLine("Starting List of boxes:");
        sortedBoxes.ForEach(b=>Console.WriteLine(b.ToString()));


        

        Console.WriteLine("Tallest pile:");
        Console.WriteLine(maxHeightStack.ToString());

        List<Pile> minHeapStack = FindMinHeapStack(sortedBoxes);

        Console.WriteLine("\nMinimal number of piles:");
        Console.WriteLine(minHeapStack.Count);
    }

    static List<Box> GenerateBoxes()
    {
        Random random = new Random();
        List<Box> boxes = new List<Box>();
        for (int i = 0; i < 10; i++)
        {
            Box box = new Box(random.Next(1, 11), random.Next(1, 11), random.Next(1, 11));
            boxes.Add(box);
        }
        return boxes;
    }

    static Pile FindMaxHeightStack(List<Box> boxes)
    {
        List<Pile> maxHeight = new List<Pile>();
        for(int i=0;i<boxes.Count;i++)
        {
            Pile pile = new Pile();
            pile.AddToPile(boxes[i]);
            maxHeight.Add(pile);
        }

        for(int i=0;i<maxHeight.Count;i++)
        {
            for(int j=i+1;j< maxHeight.Count; j++)
            {
                if (j != i)
                {
                    if (maxHeight[i].boxes.Last().width >= boxes[j].width && maxHeight[i].boxes.Last().length >= boxes[j].length)
                    {
                        maxHeight[i].AddToPile(boxes[j]);
                    }
                }
            }

        }
        Pile maxPile= maxHeight[0];
        for(int i=1;i<maxHeight.Count;i++)
        {
            if (maxPile.ReturnHeightOfPile() < maxHeight[i].ReturnHeightOfPile())
            {
                maxPile = maxHeight[i];
            }
        }
        return maxPile;
    }

    static List<Pile> FindMinHeapStack(List<Box> boxes)
    {
        //sorting by length
        boxes = boxes.OrderByDescending(x => x.length).ToList();

        List<Pile> stacks = new List<Pile>();

        foreach (var box in boxes)
        {
            bool addedToExistingStack = false;

            foreach (var stack in stacks)
            {
                var topBox = stack.boxes.LastOrDefault();
                if (topBox == null)
                {
                    stack.AddToPile(box);
                    addedToExistingStack = true;
                    break;
                }
                else if (box.length <= topBox.length && box.width <= topBox.width)
                {
                    stack.AddToPile(box);
                    addedToExistingStack = true;
                    break;
                }
            }
            if (!addedToExistingStack)
            {
                Pile newPile = new Pile();
                newPile.AddToPile(box);
                stacks.Add(newPile);
            }
        }

        return stacks;
    }
}