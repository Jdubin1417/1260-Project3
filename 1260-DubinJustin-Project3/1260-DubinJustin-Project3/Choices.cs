///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	Solution/Project:  1260-DubinJustin-Project3
//	File Name:         MenuDriver.cs
//	Description:       Enum of all choices a user can make from 1-11.                 
//	Course:            CSCI-1260 - Intro Comp Sci 2
//	Author:            Justin Dubin, dubinj@etsu.edu, East Tennessee State University
//	Created:           Wednesday, 19 October, 2022
//	Copyright:         Justin Dubin, 2022
//
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
using System.Text;
using System.Threading.Tasks;

namespace Menu
{
    /// <summary>
    /// An enum containing the values for different choices for the Menu.
    /// 
    /// These options can be modified to suit the menu as you make changes to fit your program; 
    /// these are simply an example.
    /// </summary>
    public enum Choices
    {
        CREATEPLAYLIST = 1,   //1.	Create a new Playlist for the MP3 Tracker
        CREATEMP3,            //2.	Create a new MP3 object and add it to the playlist
        EDITMP3,              //3.	Edit an existing MP3 from the playlist
        DROPMP3,              //4.	Drop an MP3 from the playlist
        DISPLAYMP3,           //5.	Display all MP3s in the playlist
        DISPLAYMP3SongTitle,  //6.	Find and display an MP3 by song title
        DISPLAYMP3Genre,      //7.	Display all MP3s on the tracker of a given genre
        DISPLAYMP3Artist,     //8.	Display all MP3s on the tracker with a given artist
        SORTMP3SongTitle,     //9.	Sort the MP3s by song title
        SORTMP3ReleaseDate,   //10.	Sort the MP3s by song release date
        QUIT                  //11. Exit      
    }
}