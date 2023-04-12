///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	Solution/Project:  1260-DubinJustin-Project3
//	File Name:         Menu.cs
//	Description:       Allows a menu to be created, displayed in a Console window, and gathers a user's choice and
//                     validates it.                  
//	Course:            CSCI-1260 - Intro Comp Sci 2
//	Author:            Justin Dubin, dubinj@etsu.edu, East Tennessee State University
//	Created:           Wednesday, 19 October, 2022
//	Copyright:         Justin Dubin, 2022
//
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu
{
    /// <summary>
    /// A Menu class which allows for the creation of a Menu and additions and deletions from its menu options. 
    /// It has methods to allow for displaying the Menu to the Console window and for getting a menu choice from the 
    /// user and validating it.
    /// </summary>
    public class Menu
    {
        private List<string> Items;         //A list of the various menu choices
        public string Title { get; set; }   //The title to display above the choices of the menu

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="title">the title to be displayed above the menu; defaults to "Menu" if not included</param>
        public Menu(string title = "Menu")
        {
            Items = new List<string>();
            Title = title;
        }
        #endregion

        #region + and - Operators
        /// <summary>
        /// Adds a choice to the menu.
        /// 
        /// Uses + syntax with a menu object and a string containing the menu choice.
        /// </summary>
        /// <param name="m">the menu to add to</param>
        /// <param name="item">the choice to add to the menu</param>
        /// <returns>the menu after adding the new choice</returns>
        public static Menu operator +(Menu m, string item)
        {
            m.Items.Add(item);
            return m;
        }

        /// <summary>
        /// Removes a choice at the given position of the menu. If the position is not a valid position in the menu, 
        /// the menu is not changed.
        /// 
        /// Uses - syntax with a menu and the position of the choice to remove.
        /// </summary>
        /// <param name="m">the menu to remove from</param>
        /// <param name="n">the number of the choice to be removed</param>
        /// <returns>the menu after removing the choice</returns>
        public static Menu operator -(Menu m, int n)
        {
            if (n > 0 && n <= m.Items.Count)
            {
                m.Items.RemoveAt(n);
            }
            return m;
        }
        #endregion

        #region Display Menu and Get User's Choice Methods
        /// <summary>
        /// Displays the menu on the console window.
        /// </summary>
        public void Display()
        {
            string dateTime = DateTime.Today.ToLongDateString();

            Console.Clear();

            Console.SetCursorPosition(Console.WindowWidth - dateTime.Length, 0); //Display the date in the top right
            Console.WriteLine(dateTime);

            Console.ForegroundColor = ConsoleColor.Red; //Display the title in a red font

            Console.WriteLine($"\n\n\t   {Title}");
            Console.Write("\t   ");
            for (int n = 0; n < Title.Length; n++)
            {
                Console.Write("-");
            }
            Console.WriteLine("\n");
            Console.ForegroundColor = ConsoleColor.Blue; //Switch back to blue text for the remainding text

            for (int n = 0; n < Items.Count; n++)
            {
                Console.WriteLine($"\t{n + 1}. {Items[n]}");
            }
        }

        /// <summary>
        /// Displays the menu using the Display method, obtains the user's menu choice, and validates it. Repeats 
        /// until a valid menu selection is made.
        /// </summary>
        /// <returns>the number of the valid menu choice made by the user</returns>
        /// <exception cref="Exception">an exception is thrown if the menu has no choices added to it</exception>
        public int GetChoice()
        {
            int choice = -1;
            string? line;
            if (Items.Count < 1)
            {
                throw new Exception("The menu is empty");
            }

            while (true)
            {
                Display();
                Console.Write("\n\t   Type the number of your choice from the menu: ");

                Console.ForegroundColor = ConsoleColor.Red;

                line = Console.ReadLine();

                Console.ForegroundColor = ConsoleColor.Blue;

                if (!Int32.TryParse(line, out choice))
                {
                    Console.WriteLine($"\n\t   Your choice is not a number between 1 and {Items.Count}. " +
                        $"Please try again.");

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n\t   ---Press any key to continue---");
                    Console.ForegroundColor = ConsoleColor.Blue;

                    Console.ReadKey();
                }
                else
                {
                    if (choice < 1 || choice > Items.Count)
                    {
                        Console.WriteLine($"\n\t   Your choice is not a number between 1 and {Items.Count}. " +
                            $"Please try again.");

                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n\t   ---Press any key to continue---");
                        Console.ForegroundColor = ConsoleColor.Blue;

                        Console.ReadKey();
                    }
                    else
                    {
                        Console.Clear();
                        return choice;
                    }
                }
            }
        }
        #endregion
    }
}
