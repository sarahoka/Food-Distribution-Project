/*
 * Sarah Okamoto
 * A2 and A3 Revision
 * 
 * Assignment includes code for A2 (mergsort algorithm from scratch) 
 * AND
 * A3 (implemnting hashtables algorithm by modifying someone else's code)
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    public class Program
    {
        static void Main(string[] args)
        {
            LinkedHashEntry lhe = new LinkedHashEntry(); //why does this exist here
            HashMap hm = new HashMap();
            //add to hashtable
            hm.put("cereal", 10);
            hm.put("applesauce", 3);
            hm.put("juice box", 12);
            //hm.printSorted();
            //hm.print(); //for testing
            User_Interface ui = new User_Interface();
            ui.program();
        }
    }

    public class User_Interface
    {
        public void program()
        {
            HashMap hm = new HashMap(); 
            Console.WriteLine("Welcome to FoodTracker!");
            Console.WriteLine("Please enter a number from the menu options below to log in.");
            Console.WriteLine("1 - Administrator");
            Console.WriteLine("2 - Donor");
            Console.WriteLine("3 - Consumer");
            Console.WriteLine("4 - Exit");
            //throw error that prompts user to enter a number 1-3
            string userInput = Console.ReadLine();
            bool goodValue = Int32.TryParse(userInput, out int caseSwitch);
            string role = "";
            switch (caseSwitch)
            {
                case 1:
                    role = "administrator";
                    Console.WriteLine("You selected 'administrator!'");
                    break;
                case 2:
                    role = "donor";
                    Console.WriteLine("You selected 'donor!'");
                    break;
                case 3:
                    role = "consumer";
                    Console.WriteLine("You selected 'consumer!'");
                    break;
                case 4:
                    Console.WriteLine("Goodbye!");
                    System.Environment.Exit(1);
                    break;
                default:
                    Console.WriteLine("Goodbye!");
                    System.Environment.Exit(1);
                    break;
            }

            if (role.Equals("administrator"))
            {
                Console.WriteLine("Please select a foodbank.");
                Console.WriteLine("1 - Hot Commodity Co (Bothell)");
                Console.WriteLine("2 - Mill Creek Community Food Bank");
                Console.WriteLine("3 - Woodinville Storehouse Food Bank");
                Console.WriteLine("4 - Exit");
                string fb = Console.ReadLine();
                bool goodVal = Int32.TryParse(fb, out int case_num);
                string bank = "";
                switch (case_num)
                {
                    case 1:
                        bank = "Hot Commodity Co";
                        Console.WriteLine("You selected 'Hot Commodity Co (Bothell)!'");
                        break;
                    case 2:
                        bank = "Mill Creek Community Food Bank";
                        Console.WriteLine("You selected 'Mill Creek Community Food Bank!'");
                        break;
                    case 3:
                        bank = "Woodinville Storehouse Food Bank";
                        Console.WriteLine("You selected 'Woodinville Storehouse Food Bank!'");
                        break;
                    case 4:
                        Console.WriteLine("Goodbye!");
                        System.Environment.Exit(1);
                        break;
                    default:
                        Console.WriteLine("Goodbye!");
                        System.Environment.Exit(1);
                        break;
                }

                /*
                 * still working on making this interactive
                 */
                while (true)
                {
                    Console.WriteLine("Please enter a number from the menu options below to perform an action.");
                    Console.WriteLine("1 - View Inventory");
                    Console.WriteLine("2 - Add Item");
                    Console.WriteLine("3 - Remove Item");
                    Console.WriteLine("4 - Exit");
                    string a_action = Console.ReadLine();
                    bool goodVal2 = Int32.TryParse(a_action, out int case_num2);
                    switch (case_num2)
                    {
                        case 1: //view inventory
                            if (bank == "Hot Commidity Co")
                            {
                                //print out inventory
                                hm.printSorted();
                                Console.WriteLine();
                            }
                            else if (bank == "Mill Creek Community Food Bank")
                            {    //print out inventory
                                hm.printSorted();
                                Console.WriteLine();
                            }
                            else
                            {
                                // print Woodinville Storehouse Food Bank
                                hm.printSorted();
                                Console.WriteLine();
                            }
                            break;
                        case 2: //add item
                            //prompt user for item (as key)
                            Console.WriteLine("Please enter the name of the item you would like to add.");
                            string key = Console.ReadLine();
                            //check if key exists
                            //if key exists --> increase quantity (value) else, add new key and ask for quantity
                            //set value = quantity
                            if (hm.find(key))
                            {
                                //incrementing happens in find method in the HashMap class
                                Console.WriteLine("Quantity of " + key + " was updated for " + bank);
                            } else
                            {
                                //can increase quantity by more than one
                                Console.WriteLine("How many " + key + " would you like to add? Please enter a number.");
                                string numAsString = Console.ReadLine();
                                bool isNum = Int32.TryParse(numAsString, out int value);
                                hm.put(key, value); 
                                Console.WriteLine(key + " was added to " + bank);
                            }
                            break;
                        case 3: //remove item
                            //call remove(key)
                            Console.WriteLine("Please enter the name of the item you would like to remove.");
                            key = Console.ReadLine();
                            hm.remove(key);
                            Console.WriteLine("Removed " + key + "."); //+ key
                            break;
                        case 4: //quit
                            Console.WriteLine("Goodbye!");
                            System.Environment.Exit(1);
                            break;
                        default:
                            Console.WriteLine("Goodbye!");
                            System.Environment.Exit(1);
                            break;
                    }
                }
            }

            else if (role.Equals("donor"))
            {
                Console.WriteLine("Please select a foodbank.");
                Console.WriteLine("1 - Hot Commodity Co (Bothell)");
                Console.WriteLine("2 - Mill Creek Community Food Bank");
                Console.WriteLine("3 - Woodinville Storehouse Food Bank");
                Console.WriteLine("4 - Exit");
                string fb = Console.ReadLine();
                bool goodVal = Int32.TryParse(fb, out int case_num); //may need to change variables so they don't match with previous
                string bank = "";
                switch (case_num)
                {
                    case 1:
                        bank = "Hot Commodity Co";
                        Console.WriteLine("You selected 'Hot Commodity Co (Bothell)!'");
                        break;
                    case 2:
                        bank = "Mill Creek Community Food Bank";
                        Console.WriteLine("You selected 'Mill Creek Community Food Bank!'");
                        break;
                    case 3:
                        bank = "Woodinville Storehouse Food Bank";
                        Console.WriteLine("You selected 'Woodinville Storehouse Food Bank!'");
                        break;
                    case 4:
                        Console.WriteLine("Goodbye!");
                        System.Environment.Exit(1);
                        break;
                    default:
                        Console.WriteLine("Goodbye!");
                        System.Environment.Exit(1);
                        break;
                }

            while (true)
            {
                Console.WriteLine("Please enter a number from the menu options below to perform an action.");
                Console.WriteLine("1 - View Inventory");
                Console.WriteLine("2 - Exit");
                string d_action = Console.ReadLine();
                bool goodVal2 = Int32.TryParse(d_action, out int case_num3);
                switch (case_num3)
                {
                    case 1: //view inventory
                        if (bank == "Hot Commidity Co")
                        {
                            //print out inventory
                            hm.printSorted();
                            Console.WriteLine();
                        }
                        else if (bank == "Mill Creek Community Food Bank")
                        {    //print out inventory
                            hm.printSorted();
                            Console.WriteLine();
                        }
                        else
                        {
                            // print Woodinville Storehouse Food Bank
                            hm.printSorted();
                            Console.WriteLine();
                        }
                        break;
                    case 2: //quit
                        Console.WriteLine("Goodbye!");
                        System.Environment.Exit(1);
                        break;
                    default:
                        Console.WriteLine("Goodbye!");
                        System.Environment.Exit(1);
                        break;
                }
            }
        }
        else if (role.Equals("consumer")) //as of right now, the consumer and donor capabilities are the same, may be different in the future, but can simplify if not
        {
            Console.WriteLine("Please select a foodbank.");
            Console.WriteLine("1 - Hot Commodity Co (Bothell)");
            Console.WriteLine("2 - Mill Creek Community Food Bank");
            Console.WriteLine("3 - Woodinville Storehouse Food Bank");
            Console.WriteLine("4 - Exit");
            string fb = Console.ReadLine();
            bool goodVal = Int32.TryParse(fb, out int case_num); //may need to change variables so they don't match with previous
            string bank = "";
            switch (case_num)
            {
                case 1:
                    bank = "Hot Commodity Co";
                    Console.WriteLine("You selected 'Hot Commodity Co (Bothell)!'");
                    break;
                case 2:
                    bank = "Mill Creek Community Food Bank";
                    Console.WriteLine("You selected 'Mill Creek Community Food Bank!'");
                    break;
                case 3:
                    bank = "Woodinville Storehouse Food Bank";
                    Console.WriteLine("You selected 'Woodinville Storehouse Food Bank!'");
                    break;
                case 4:
                    Console.WriteLine("Goodbye!");
                    System.Environment.Exit(1);
                    break;
                default:
                    Console.WriteLine("Goodbye!");
                    System.Environment.Exit(1);
                    break;
            }

            while (true)
            {
                Console.WriteLine("Please enter a number from the menu options below to perform an action.");
                Console.WriteLine("1 - View Inventory");
                Console.WriteLine("2 - Exit");
                string c_action = Console.ReadLine();
                bool goodVal2 = Int32.TryParse(c_action, out int case_num4);
                switch (case_num4)
                {
                    case 1: //view inventory
                        if (bank == "Hot Commidity Co")
                        {
                            //print out inventory
                            hm.printSorted();
                            Console.WriteLine();
                        }
                        else if (bank == "Mill Creek Community Food Bank")
                        {    //print out inventory
                            hm.printSorted();
                            Console.WriteLine();
                        }
                        else
                        {
                            // print Woodinville Storehouse Food Bank
                            hm.printSorted();
                            Console.WriteLine();
                        }
                        break;
                    case 2: //quit
                        Console.WriteLine("Goodbye!");
                        System.Environment.Exit(1);
                        break;
                    default:
                        Console.WriteLine("Goodbye!");
                        System.Environment.Exit(1);
                        break;
                }
            }
        }
    }
}

/*
    * Mergesort Implementation (from scratch)
    * @Sarah Okamoto
    * 
    * Where left = 0 (is the start of the array), right = quantity.length-1 (end of the array),
    * and middle = (left+right)/2
    * 
    * Total Run Time: O(N*LogN)
    * 
    * Pseudocode Referenced (but still built own solution):
    * https://www.lynda.com/Java-tutorials/Merge-sort-Pseudocode/656821/672120-4.html
    * https://www.lynda.com/Java-tutorials/Merge-step-Pseudocode/656821/672121-4.html
    */
public class Mergesort
    {
        public void MergeSortMain(int[] quantity, int left, int right, int middle)
        {
            MergeSort(quantity);
            Merge(quantity, left, right, middle);
            MergeSortAlgorithm(quantity, left, right);
        }
        /*
            * MergeSort() Method
            * Sets array values equal to the values from each key in the hash table
            * Eventually want to convert values directly rather than hard coding the values into the array
            */
        public void MergeSort(int[] quantity)
        {
            MergeSortAlgorithm(quantity, 0, quantity.Length - 1);
        }

        /*
            * Merge() Method
            * Merges two arrays by comparing the values starting from the left most values of each array
            * Smaller value is put into tempArray
            */
        public void Merge(int[] quantity, int left, int middle, int right)
        {
            //may need to declare left, middle, and right in here w/o parameters
            //int left = 0;
            //int right = quantity.Length;
            //int middle = (left+right)/2;
            int sizeLeft = (middle-left)+1;
            int sizeRight = right - middle;
            int[] tempLeft = new int[sizeLeft]; //holds half of elements (before middle)
            int[] tempRight = new int[sizeRight]; //holds half of elements (after middle)
                
            //copy elements into respective halves
            //left half
            for(int i = 0; i < sizeLeft; i++)
            {
                tempLeft[i] = quantity[left + i]; 
            }

            //right half
            for (int j = 0; j < sizeRight; j++)
            {
                tempRight[j] = quantity[middle + 1 + j]; //starting point is middle+1, then increments by j 
            }

            int x = 0;
            int y = 0;
            for(int k = 0; k < right; k++)
            {
                if(tempLeft[x] <= tempRight[y])
                {
                    quantity[k] = tempLeft[x];
                    x++; //increments left pointer by one because we have already moved the element back into the array
                }
                else
                {
                    quantity[k] = tempRight[y];
                    y++; //increments right pointer by one
                }
            }
        }
            
        /*
            * MergeSortAlgorithm
            * Recursive Merge Sort Algorithm
            * This method first calls merge sort on the first half of the array, then the second half, until
            * each array is only one element long
            * The the algorithm merges each array until left with one, sorted array
            */
        public void MergeSortAlgorithm(int[] quantity, int left, int right)
        {
            int middle;
            if (right > left)
            {
                middle = (left + right) / 2; //middle will be rounded down, always giving us the middle value or slightly less because I used ints
                MergeSortAlgorithm(quantity, left, middle); //will call merge sort on first half of the elements
                MergeSortAlgorithm(quantity, (middle + 1), right); //wil call merge sort on the second half of the elements
                Merge(quantity, left, middle, right);
            }
        }
    }

/*
* Hash Table Implementation (modified code from someone else)
* Source: http://www.algolist.net/Data_structures/Hash_table/Chaining
* 
* Licensing Information:
* No explicit license, but the site owners have this message at the bottom of each page:
* "Help us [AlgoList] keep sharing free knowledge and write new tutorials."
*/


public class LinkedHashEntry
{
    private string key;
    private int value;
    private LinkedHashEntry next;
    private object key1;
    private object value1;

    public LinkedHashEntry() //added default constuctor
    {

    }

    LinkedHashEntry(string key, int value)
    {
        this.key = key;
        this.value = value;
        this.next = null;
    }

    public LinkedHashEntry(object key1, object value1)
    {
        this.key1 = key1;
        this.value1 = value1;
    }

    public int getValue()
    {
        return value;
    }

    public void setValue(int value)
    {
        this.value = value;
    }

    public int getKey()
    {
        //converts key to int
        return key.GetHashCode();
    }

    public LinkedHashEntry getNext()
    {
        return next;
    }

    public void setNext(LinkedHashEntry next)
    {
        this.next = next;
    }
}

public class HashMap
{
    //changed from final static int to const int
    private const int TABLE_SIZE = 128;
    //made variables static so that object could be created in this class
    LinkedHashEntry lhe = new LinkedHashEntry();
    //created new LinkedHashEntry object to define key and value in this class by calling getKey() and getValue()
    // int key = lhe.getKey();
    // int value = lhe.getValue();
    LinkedHashEntry[] table;

    public HashMap()
    {
        table = new LinkedHashEntry[TABLE_SIZE];
        for (int i = 0; i < TABLE_SIZE; i++)
            table[i] = null;
    }

    //key will be the name of the food converted to ASCII, value will be quanitity of food as an int
    public int get(string keyString)
    {
        int key = keyString.GetHashCode();
        //hash fuction using 
        int hash = (key % TABLE_SIZE);
        if (table[hash] == null)
            return -1;
        else
        {
            LinkedHashEntry entry = table[hash];
            while (entry != null && entry.getKey() != key)
                entry = entry.getNext();
            if (entry == null)
                return -1;
            else
                return entry.getValue();
        }
    }

    public void put(string keyString, int value)
    {
        int key = keyString.GetHashCode();
        int hash = (key % TABLE_SIZE);
        if(hash < 0) //if the has value is negative, make it positive
        {
            hash *= -1;
        }

        if (table[hash] == null)
            table[hash] = new LinkedHashEntry(key, value);

        else
        {
            LinkedHashEntry entry = table[hash];

            while (entry.getNext() != null && entry.getKey() != key)
                entry = entry.getNext();

            if (entry.getKey() == key)
                entry.setValue(value);

            else
                entry.setNext(new LinkedHashEntry(key, value));
        }
    }

    //add print method that prints all values in hash table, unsorted
    public void print()
    {
        LinkedHashEntry entry = table[0];

        while (entry.getNext() != null)
        {
            entry = entry.getNext();
            Console.WriteLine(entry);
        }
    }

        //method puts has table elements into an array and then calls mergesort
        public void printSorted()
        {
            LinkedHashEntry entry = table[0];
            int[] toBeSorted = new int[TABLE_SIZE]; //array to store hashtable values
            int count = 0; //keeps track of array placement
            //adds all elements into an array
            while (entry != null && entry.getNext() != null)
            {
                toBeSorted[count] = entry.getValue();
                entry = entry.getNext();
                count++;
            }

            //sorts array
            Mergesort m = new Mergesort();
            int left = 0;
            int right = toBeSorted.Length;
            int middle = (left + right) / 2;
            m.MergeSortMain(toBeSorted, left, right, middle);

            //prints entries
            for(int i = 0; i < toBeSorted.Length; i++)
            {
                Console.WriteLine(toBeSorted[i]);
            }
           /* while (entry.getNext() != null)
            {
                entry = entry.getNext();
                Console.WriteLine(entry);
            }
            */
        }

        //find method will find the key and will help determine if we should increment the value of a key or add a new item
        public bool find(string userKey)
        {
            int key = userKey.GetHashCode();
            int hash = (key % TABLE_SIZE);
            if(hash < 0) //if the has value is negative, make it positive
        {
            hash *= -1;
        }
            if (table[hash] != null)
            {
                LinkedHashEntry entry = table[hash];

                while (entry.getNext() != null && entry.getKey() != key)
                {
                    entry = entry.getNext();
                }

                if(entry.getKey() == key)
                {
                    //increments value by one
                    int value = entry.getValue();
                    entry.setValue(value++);
                    return true;
                } 
                else
                {
                    return false;
                }
            }

            else
            {
                return false;
            }
        }

        public void remove(string userKey)
        {
            int key = userKey.GetHashCode();
            int hash = (key % TABLE_SIZE);
            if (table[hash] != null)
            {
                LinkedHashEntry prevEntry = null;
                LinkedHashEntry entry = table[hash];

                while (entry.getNext() != null && entry.getKey() != key)
                {
                    prevEntry = entry;
                    entry = entry.getNext();
                }

                if (entry.getKey() == key)
                {
                    if (prevEntry == null)
                        table[hash] = entry.getNext();
                    else
                        prevEntry.setNext(entry.getNext());
                }
            }
        }
    }
}
