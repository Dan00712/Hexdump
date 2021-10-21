using System;

namespace Hexdump{
    class Program{
        static void Main(string[] args){
			var tmp = ParseParams(args);
			if(tmp is not null){
				//System.Console.WriteLine("OFfset:\t{0}", tmp.Offset);
				//System.Console.WriteLine("Lines:\t{0}", tmp.Lines);
            	Hexdump hexdump= new Hexdump(tmp);
				hexdump.Generate();
			}
			else{
				System.Console.WriteLine("Error while Parsing Parameters");
			}
        }

		static HexdumpParams ParseParams(String[] args){
			HexdumpParams par = new HexdumpParams();
			if(args.Length==0){
				return null;
			}
			if(args.Length>=1){
				par.Source = args[0];
			}

			par.CustomColors= false;

			for(int i= 0; i< args.Length; i++){
				switch(args[i]){
					case "--no-PTC":
						par.PrintToConsole=false;
						break;
					
					case "-d":
					case "--dest":
						par.CustomDest= true;
						par.Dst= args[++i].EndsWith(".hexdump") ? args[i] : args[i] + "hexdump";
						break;
					
					case "-dS":
					case "-destBasedSource":
						par.CustomDest = true;
						par.Dst = par.Source+".hexdump";
						break;
					
					case "-l":
					case "--lines":
						//System.Console.WriteLine("{0}\t{1}", args[i], args[i+1]);
						par.Lines = int.Parse(args[++i]);
						break;

					case "-o":
					case "--offset":
						//System.Console.WriteLine("{0}\t{1}", args[i], args[i+1]);
						par.Offset = int.Parse(args[++i]);
						break;
					
					default:
						break;
				}
			}
			return par;
		}		
    }
}
