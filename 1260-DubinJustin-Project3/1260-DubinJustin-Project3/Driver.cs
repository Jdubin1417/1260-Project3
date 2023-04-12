///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	Solution/Project:  1260-DubinJustin-Project3
//	File Name:         Driver.cs
//	Description:       Allow user to create username and select menu options 1-11 to create Playlist File and display it.
//                     Allows user to create, edit, or drop MP3 File. Allows user to Display MP3s in a playlist by title, genre,
//                     artist, or all MP3s in a playlist. Allows user to sort MP3s by title or release date, or quit based on user-input                  
//	Course:            CSCI-1260 - Intro Comp Sci 2
//	Author:            Justin Dubin, dubinj@etsu.edu, East Tennessee State University
//	Created:           Wednesday, 19 October, 2022
//	Copyright:         Justin Dubin, 2022
//
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using _1260_DubinJustin_Project3;
using Menu;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu
{
    /// <summary>
    /// Provides Menu class and its functionality. 
    /// </summary>
    public class Driver
    {
        /// <summary>
        /// Creates a Menu object, adds options to it, and gives functionality. User will create playlist and fill playlist with MP3 objects. Main method allows user to select options 
        /// to call methods for sorting, displaying, and creating MP3s in a playlist
        /// </summary>
        public static void Main()
        {
            //Set up the look and feel of the Console window
            Console.BackgroundColor = ConsoleColor.Black;       //Change the background color of the window to white
            Console.ForegroundColor = ConsoleColor.Blue;        //Change the font color to blue
            Console.Title = "Menu Application";   //Set the text of the title bar (top left)

            Console.Write($"\n\n\tWelcome! In this file you can create or open an MP3! Please enter your name: ");
            String UserName = Console.ReadLine(); //Allows User to create Username

            Menu menu = new Menu("Menu");
            menu = menu + "Create new Playlist" +
                "Create new MP3 File to add to Playlist" +
                "Edit Existing MP3 File" +
                "Drop MP3 from Playlist" +
                "Display all MP3 Files in Playlist" +
                "Display all MP3 Files by song title" +
                "Display all MP3 Files by genre" +
                "Display all MP3 Files by artist" +
                "Sort MP3 Files by song title" +
                "Sort MP3 Files by release date" +
                "Quit";

            String SongTitle = " "; //Initilizing Attributes
            String Artist = " ";
            String SongReleaseDateString = " ";
            DateTime ParsedDate;
            String PlaybackTime = " ";
            Decimal DownloadCost = 0;
            Double FileSize = 0;
            String Path = " ";
            MP3 mp3 = null;
            Playlist playlist = null;

            Choices choice = (Choices)menu.GetChoice();
            while (choice != Choices.QUIT)
            {

                switch (choice) //Gives menu Choices to user and allows user to
                                //create attributes for MP3 File
                {
                    case Choices.CREATEPLAYLIST:    //Allows user to create playlist. Asks for Playlist Name and Date. Then displays Playlist Name, Date Created, and Username. 
                        Console.WriteLine("You selected Create a New Playlist\n");

                        Console.Write("Enter Playlist Name: ");
                        string PlaylistName = Console.ReadLine();
                        PlaylistDate:
                        Console.WriteLine("FORMAT: MMM DD, YYYY");
                        Console.WriteLine("EX: Jan 1, 2009");
                        Console.Write("Enter Release Date here: ");
                        try
                        {
                            string PlaylistCreationDateStr = Console.ReadLine();
                            ParsedDate = DateTime.Parse(PlaylistCreationDateStr);

                            playlist = new Playlist(PlaylistName, UserName, PlaylistCreationDateStr, ParsedDate);
                            Console.WriteLine("\n" + playlist.ToString());
                        }
                        catch
                        {
                            Console.WriteLine("Invalid Date, Try again.");
                            goto PlaylistDate;
                        }
                        Console.WriteLine();
                        Console.WriteLine("Press any Key to Continue!");
                        Console.ReadKey();
                        break;

                    case Choices.CREATEMP3:
                        Console.WriteLine("You selected to Create an MP3");
                        if (playlist == null)
                        {
                            Console.WriteLine("Must Create Playlist First. Please select option 1 in the menu to create Playlist!");
                        }
                        else
                        {
                        ERROR1:             //Does not allow user to enter wrong values into MP3 Creation
                            Console.Write("Enter Song Title here: ");
                            SongTitle = Console.ReadLine();
                            Console.Write("Enter Artist here: ");
                            Artist = Console.ReadLine();
                            Console.WriteLine("FORMAT: MMM DD, YYYY");
                            Console.WriteLine("EX: Jan 1, 2009");
                            Console.Write("Enter Release Date here: ");
                            try
                            {
                                SongReleaseDateString = Console.ReadLine();
                                ParsedDate = DateTime.Parse(SongReleaseDateString);             //Converts string of date into actual DateTime
                                Console.Write("Enter Song Playtime IN MINUTES here: ");
                                PlaybackTime = Console.ReadLine();
                                GenreVal:  //Validates Genre Input
                                Console.WriteLine("Rock      = 1\n" +
                                                  "Pop       = 2\n" +
                                                  "Jazz      = 3\n" +
                                                  "Country   = 4\n" +
                                                  "Classical = 5\n" +
                                                  "Other     = 6");
                                Console.Write("Enter Genre From List: ");
                                int Genre2 = int.Parse(Console.ReadLine());
                                if (Genre2 > 0 && Genre2 < 7)
                                {

                                }
                                else
                                {
                                    Console.WriteLine("Enter value from 1-6 for Genre, try again.");
                                    goto GenreVal;
                                }

                                Genre myGenre2 = (Genre)Genre2;
                                Console.Write("Enter Download Cost here: ");
                                DownloadCost = Convert.ToDecimal(Console.ReadLine());
                                Console.Write("Enter File Size in MBs here: ");
                                FileSize = Convert.ToDouble(Console.ReadLine());
                                Console.Write("Enter Album Photo Path here: ");
                                Path = Console.ReadLine();
                                mp3 = new MP3(SongTitle, Artist, SongReleaseDateString, ParsedDate, PlaybackTime, myGenre2, DownloadCost, FileSize, Path);
                            }
                            catch
                            {
                                Console.WriteLine("Invalid Input, try creating MP3 again!");
                                goto ERROR1;
                            }
                                
                            playlist.AddToPlaylist(mp3); //Adds new MP3 Object to playlist. 

                            Console.WriteLine(mp3.ToString());  //Displays new MP3
                        }
                            Console.WriteLine();
                            Console.WriteLine("Press any Key to Continue!");
                            Console.ReadKey();
                        break;
                    case Choices.EDITMP3:               //Allows user to Edit an MP3 of choice by removing it and creating a new one
                        Console.WriteLine("You selected to Edit MP3");
                        if (playlist == null)
                        {
                            Console.WriteLine("Must Create Playlist First!");
                        }
                        else
                        {
                            Console.WriteLine(playlist.ToString());
                            Console.Write("Enter MP3 song number to edit here:");
                            int EditSong = Convert.ToInt32(Console.ReadLine()) -1 ;
                            Console.Write("Enter MP3 Title here: ");
                            SongTitle = Console.ReadLine();

                            Console.Write("Enter Artist here: ");
                            Artist = Console.ReadLine();
                            Console.WriteLine("FORMAT: MMM DD, YYYY");
                            Console.WriteLine("EX: Jan 1, 2009");
                            Console.Write("Enter Release Date here: ");
                            SongReleaseDateString = Console.ReadLine();
                            ParsedDate = DateTime.Parse(SongReleaseDateString);         //Converts string of date into actual DateTime
                            Console.Write("Enter Song Playtime IN MINUTES here: ");
                            PlaybackTime = Console.ReadLine();

                            
                            Console.WriteLine("Rock      = 1\n" +
                                              "Pop       = 2\n" +
                                              "Jazz      = 3\n" +
                                              "Country   = 4\n" +
                                              "Classical = 5\n" +
                                              "Other     = 6");
                            Console.Write("Enter Genre From List: ");
                            int Genre = Convert.ToInt32(Console.ReadLine());
                            Genre myGenre = (Genre)Genre;
                            Console.Write("Enter Download Cost here: ");
                            DownloadCost = Convert.ToDecimal(Console.ReadLine());
                            Console.Write("Enter File Size in MBs here: ");
                            FileSize = Convert.ToDouble(Console.ReadLine());
                            Console.Write("Enter Album Photo Path here: ");
                            Path = Console.ReadLine();
                            mp3 = new MP3(SongTitle, Artist, SongReleaseDateString, ParsedDate, PlaybackTime, myGenre, DownloadCost, FileSize, Path);



                            Console.WriteLine(mp3.ToString());              //Displays MP3 Object
                            playlist.EditPlaylist(EditSong, mp3);           //Passes MP3 Object into EditPlaylist Method
                        }
                            Console.WriteLine();
                            Console.WriteLine("Press any Key to Continue!");
                            Console.ReadKey();    
                        break;
                    case Choices.DROPMP3:
                        Console.WriteLine("You Selected to Remove an MP3 from Playlist");
                        if (mp3 == null)
                        {
                            Console.WriteLine("You must Create an MP3 File First. Please select option 2 in the menu to create MP3 File!");
                        }
                        else
                        {
                            Console.WriteLine(playlist.ToString());
                            
                           
                            playlist.DropPlaylist();
                            Console.WriteLine(playlist.ToString());
                        }
                            Console.WriteLine();
                            Console.WriteLine("Press any Key to Continue!");
                            Console.ReadKey();
                        break;
                    case Choices.DISPLAYMP3:                                //Displays all songs in Playlist
                                             
                        Console.WriteLine("You selected Display all songs in Playlist");
                        if (mp3 == null)
                        {
                            Console.WriteLine("You must Create an MP3 File First. Please select option 2 in the menu to create MP3 File!");
                        }
                        else
                        {
                            Console.WriteLine(playlist.ToString());        
                        }
                            Console.WriteLine();
                            Console.WriteLine("Press any Key to Continue!");
                            Console.ReadKey();
                        break;
                    case Choices.DISPLAYMP3SongTitle:                       //Displays all songs by song title in playlist
                        Console.WriteLine("You selected to search an MP3 by Song Title");
                        if (mp3 == null)
                        {
                            Console.WriteLine("You must Create an MP3 File First. Please select option 2 in the menu to create MP3 File!");
                        }
                        else
                        {
                            Console.Write("Enter Song Title to search here: ");
                            string SearchTitle = Console.ReadLine();
                            playlist.DisplayByTitle(SearchTitle);
                        }
                            Console.WriteLine();
                            Console.WriteLine("Press any Key to Continue!");
                            Console.ReadKey();
                        break;
                    case Choices.DISPLAYMP3Genre:                          //Displays all songs by genre in playlist
                        Console.WriteLine("You selected Display all songs in a genre");
                        if (mp3 == null)
                        {
                            Console.WriteLine("You must Create an MP3 File First. Please select option 2 in the menu to create MP3 File!");
                        }
                        else
                        {
                            Console.WriteLine("Type Genre Name to Search: ");
                            Console.WriteLine("Rock\n" +
                                               "Pop\n" +
                                               "Jazz\n" +
                                               "Country\n" +
                                               "Classical\n" +
                                               "Other");
                            string SearchedGenre = Console.ReadLine();
                            playlist.DisplayByGenre(SearchedGenre);
                        }
                            Console.WriteLine();
                            Console.WriteLine("Press any Key to Continue!");
                            Console.ReadKey();
                        break;
                    case Choices.DISPLAYMP3Artist:                      //Displays all songs by artist in playlist
                        Console.WriteLine("You selected Display all songs by an artist");
                        if (mp3 == null)
                        {
                            Console.WriteLine("You must Create an MP3 File First. Please select option 2 in the menu to create MP3 File!");
                        }
                        else
                        {
                            Console.Write("Type Artist Name to Search: ");
                            string SearchedArtist = Console.ReadLine();
                            playlist.DisplayByArtist(SearchedArtist);
                        }
                            Console.WriteLine();
                            Console.WriteLine("Press any Key to Continue!");
                            Console.ReadLine();
                         break;
                    case Choices.SORTMP3SongTitle:                      //Sorts all songs by Song Title
                        Console.WriteLine("You selected sort all songs by title");
                        if (mp3 == null)
                        {
                            Console.WriteLine("You must Create an MP3 File First. Please select option 2 in the menu to create MP3 File!");
                        }
                        else
                        {
                            playlist.SortByTitle();
                        }
                            Console.WriteLine();
                            Console.WriteLine("Press any Key to Continue!");
                            Console.ReadLine();
                        break;
                    case Choices.SORTMP3ReleaseDate:                   //Sorts all songs by release date
                        Console.WriteLine("You selected sort all songs by release date");
                        if (mp3 == null)
                        {
                            Console.WriteLine("You must Create an MP3 File First. Please select option 2 in the menu to create MP3 File!");
                        }
                        else
                        {
                            var parsedDate = DateTime.Parse(SongReleaseDateString);     
                            playlist.SortByDate();
                        }
                            Console.WriteLine();
                            Console.WriteLine("Press any Key to Continue!");
                            Console.ReadLine();
                        break;
                }
                choice = (Choices)menu.GetChoice();
            }
            if (choice == Choices.QUIT) //Allows user to exit program at any point from menu
            {
                Console.WriteLine("Press Any Key to Quit");
                Console.WriteLine("Goodbye, " + UserName);
                Console.ReadKey();
            }
        }
    }
}