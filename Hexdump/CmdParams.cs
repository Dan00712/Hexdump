using System;
using System.IO;


namespace Hexdump{
	public class HexdumpParams{
		public bool PrintToConsole{get;set;}
		public bool CustomColors{get;set;}
		public ConsoleColor Front{get;set;}
		public ConsoleColor Back{get;set;}
		public int Lines{get;set;}
		public int Offset{get;set;}
		public string Source{get;set;}

		public bool CustomDest{get; set;}
		public string Dst{get; set;}
	}
}