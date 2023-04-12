///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	Solution/Project:  1260-DubinJustin-Project3
//	File Name:         Genre.cs
//	Description:       ENUM that gives genres the user can input into their MP3 file. 6 Genres to choose from starting from 1
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
    /// Creates enum of all different genres for the user to enter for the MP3 class
    /// </summary>
    public enum Genre
    {
        Rock = 1, //Default starts at 1 instead of 0
        Pop, //2
        Jazz, //3
        Country, //4
        Classical, //5
        Other //6
    }
}
