///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	Solution/Project:  1260-DubinJustin-Project3
//	File Name:         Playlist.cs
//	Description:       Allows Playlist to be created, MP3 Objects to be passed into it, and allows functionality
//	                   for Displaying, Dropping, Editing, and Sorting MP3s.
//	Course:            CSCI-1260 - Intro Comp Sci 2
//	Author:            Justin Dubin, dubinj@etsu.edu, East Tennessee State University
//	Created:           Wednesday, 19 October, 2022
//	Copyright:         Justin Dubin, 2022
//
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
using Menu;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace _1260_DubinJustin_Project3
{
    /// <summary>
    /// Allows Playlist to be created, MP3 Objects to be passed into it, and allows functionality
    /// for Displaying, Dropping, Editing, and Sorting MP3s.
    /// </summary>
    public class Playlist
    {
        private List<MP3> songList = new List<MP3>();
        public String playlistName { get; set; }
        public String PlaylistCreator { get; set; }
        public String playlistCreationDateStr { get; set; }
        public DateTime playlistCreationDate { get; set; }
        /// <summary>
        /// Default Constructror of Playlist. Fills playlist with default values and creates a new list
        /// </summary>
        public Playlist()
        {
            songList = new List<MP3>();
            playlistName = "";
            PlaylistCreator = "";
            playlistCreationDate = DateTime.Parse(playlistCreationDateStr); ;
        }

        /// <summary>
        /// Passes in values from User to create Parameterized constructor
        /// </summary>
        /// <param name="PlaylistName"></param>
        /// <param name="UserName"></param>
        /// <param name="PlaylistCreationDateStr"></param>
        /// <param name="PlaylistCreationDate"></param>
        public Playlist(string PlaylistName, string UserName, string PlaylistCreationDateStr, DateTime PlaylistCreationDate)
        {
            songList = new List<MP3>();
            playlistName = PlaylistName;
            PlaylistCreator = UserName;
            playlistCreationDateStr = PlaylistCreationDateStr;
            playlistCreationDate = playlistCreationDate;
        }

        /// <summary>
        /// MP3 object passed in is added to playlist
        /// </summary>
        /// <param name="mp3"></param>
        public void AddToPlaylist(MP3 mp3)
        {
            songList.Add(mp3);
        }

        /// <summary>
        /// MP3 Object selected by user and passed in is removed and remade by user
        /// </summary>
        /// <param name="EditSong"></param>
        /// <param name="EditMP3"></param>
        public void EditPlaylist(int EditSong, MP3 EditMP3)
        {
            songList.RemoveAt(EditSong);
            songList.Insert(EditSong, EditMP3);
        }

        /// <summary>
        /// Removes MP3 from Playlist
        /// </summary>
        public void DropPlaylist()
        {
            try
            {
            TryAgain:       //Allows for no crashes if user attempts to enter an invalid entry
                Console.Write("Enter MP3 song number to remove here:");
                int DropSong =  Convert.ToInt32(Console.ReadLine()) - 1;
                if (DropSong > songList.Count)
                {
                    Console.WriteLine("Invalid Entry, try again!");
                    goto TryAgain;
                }
                else if (DropSong < 0)
                {
                    Console.WriteLine("Invalid Entry, try again!");
                    goto TryAgain;
                }
                else
                {
                    songList.RemoveAt(DropSong);
                }
            }
            catch
                {
                    Console.WriteLine("Invalid Entry, Try Again!");
                }
            
            
        }

        /// <summary>
        /// Passes in title from user and uses it to search for MP3 Object
        /// </summary>
        /// <param name="SearchTitle"></param>
        public void DisplayByTitle(string SearchTitle)
        {
            Console.WriteLine(songList.Find(i => i.SongTitle == SearchTitle));      //Find() method searches for an element that matches conditions
                                                                                    //and returns the first occurence found
        }


        /// <summary>
        /// Takes genre entered from user in string format, and uses it to search for an MP3 Object of a specific genre
        /// </summary>
        /// <param name="SearchGenre"></param>
        public void DisplayByGenre(string SearchGenre)
        {
            Genre userGenre = (Genre)Enum.Parse(typeof(Genre), SearchGenre);
            List<MP3> newMP3list = songList.FindAll(i => i.Genre == userGenre);
            for (int i = 0; i < newMP3list.Count; i++)
            {
                Console.WriteLine("\n" + newMP3list[i]);       //typeof gets a type and uses it as an argument. Returns type specified
                                                               
            }
        }

        /// <summary>
        /// Takes artist entered from user, and uses it to search for an MP3 object by a specific artist
        /// </summary>
        /// <param name="SearchArtist"></param>
        public void DisplayByArtist(string SearchArtist)
        {
            List<MP3> newMP3list = songList.FindAll(i => i.Artist == SearchArtist);
            for (int i = 0; i < newMP3list.Count; i++)
            {
                Console.WriteLine("\n" + newMP3list[i]);       //FindAll() method searches for all elements emeeting a specific condition
            }
        }

        /// <summary>
        /// Sorts all MP3s in a playlist by title in ascending order
        /// </summary>
        public void SortByTitle()
        {
            var sorted = songList.OrderBy(i => i.SongTitle).ToList();       //String.Join method Concatenates the elements of a specified array or the members
                                                                            //of a collection, using the specified separator between each element or member.
        }

        /// <summary>
        /// Sorts all MP3s in a playlist by title in ascending order
        /// </summary>
        public void SortByDate()
        {
            var sorted = songList.OrderBy(i => i.ParsedDate).ToList();      
            Console.WriteLine(String.Join(Environment.NewLine, sorted));

            /* The ToList() method forces immediate query evaluation and returns a List<T> 
             * that contains the query results.
             * 
             * String.Join method Concatenates the elements of a specified array or the members
             * of a collection, using the specified separator between each element or member.
             * 
             * In lambda expressions, the lambda operator => separates the input parameters on the 
             * left side from the lambda body on the right side. is much more concise than other methods. 
             * 
             * of a collection, using the specified separator between each element or member.
             * Environment. NewLine can be used in conjunction with language-specific newline support such as 
             * the escape characters '\r' and '\n' in Microsoft C# and C/C++, or vbCrLf in Microsoft Visual Basic.
             * NewLine is automatically appended to text processed by the Console.WriteLine and 
             *  StringBuilder.AppendLine methods. (It creates a New Line in between var sorted)
             *  
             *  Definitions found from https://learn.microsoft.com/en-us/dotnet/api/
             *  
             *  var sorted sorts songList in ascending order using OrderBy and i as a parameter. The results are returned in a list
             *      using the ToList()
             *  The Console.WriteLine displays the sorted variable list  with a new line seperating during sorting. 
             */
        }

        /// <summary>
        /// Takes Playlist User values and converts them into readable string format, and then displays MP3 values inside of the Playlist
        /// </summary>
        /// <returns>PartOne + PlaylistStr</returns>
        public override string ToString()
        {
            string PlaylistStr = " ";

            var PartOne = "Playlist Name: " + playlistName +
                    "\nPlaylist Creation Date: " + playlistCreationDateStr +
                    "\nPlaylist Creator: " + PlaylistCreator;
            for (int i = 0; i < songList.Count; i++)
            {
                
                PlaylistStr += "\nMP3" + ": " + (i + 1) + "\n----------------------\n" + songList[i].ToString() + "\n\n";
            }
            return PartOne + PlaylistStr;
        }
    }
}
