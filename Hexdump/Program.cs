using System;

namespace Hexdump{
    class Program{
        static void Main(string[] args){
            Hexdump hexdump= new Hexdump(new HexdumpParams(){
				CustomDest= false,
				PrintToConsole=true,
				CustomColors=true,
				Front = ConsoleColor.DarkGreen,
				Back =ConsoleColor.Black,
				Dst=null,
				Source = args[0]
			});

			hexdump.Generate();
        }

		/*static HexdumpParams ParseCmdParams(string[] args){
			HexdumpParams parameters = new HexdumpParams();

			for(int i= 0; i<args.Length; i++){

				switch(args[i]){
					case "-s":
						parameters.Source = args[++i];
						break;
					case "--source":
						parameters.Source = args[++i];
						break;
					
					case "-CCC":
						parameters.CustomColors = true;
						break;
					case "--sustomColourColors":
						parameters.CustomColors = true;
						break;
					
					case "-NPTC":
						parameters.PrintToConsole=false;
						break;
					
					case "-o":
						parameters.Offset = int.Parse(args[++i]);
						break;
					case "--offset":
						parameters.Offset = int.Parse(args[++i]);
						break;

					case "-d":
						parameters.CustomDest= true;
						parameters.Dst = args[++i];
						break;
					case "--dest":
						parameters.CustomDest= true;
						parameters.Dst = args[++i];
						break;

					default:
						System.Console.WriteLine("Invalid Cmd args");
						break;
				}
				
			}
			parameters.CustomColors=false;
				return parameters;
		}//*/
    }
}
