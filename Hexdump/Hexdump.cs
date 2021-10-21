using System;
using System.IO;
using System.Text;


namespace Hexdump{
	public class Hexdump{
		private HexdumpParams _params;

		public Hexdump(String Scr){
			_params = new HexdumpParams(){
				CustomColors = false,
				Lines = 0,
				Offset = 0,
				Source = Scr,
				CustomDest = false,
				Dst= null
			};
		}

		public Hexdump(HexdumpParams param){
			_params = param;
		}

		public void Generate(){
			int adress = _params.Offset;
			int lineC = _params.Lines;
			StreamWriter dst = null;
			
			if(_params.CustomDest){
				
				if(File.Exists(_params.Dst)){
					File.WriteAllText(_params.Dst, String.Empty);
				}
				dst = new StreamWriter(new FileStream(_params.Dst, FileMode.OpenOrCreate, FileAccess.Write));
			}

			if(_params.CustomColors&& _params.PrintToConsole){
				SetColor();
			}


			using(FileStream source = new FileStream(_params.Source, FileMode.Open, FileAccess.Read)){
				int readBytes;
				byte[] buffer = new byte[16];
				source.Seek(adress, SeekOrigin.Begin);

				for(int i=0;
					(i<lineC | lineC==0) &&
					(readBytes = source.Read(buffer, 0, buffer.Length)) !=0; 
					i++, adress+=16){

					PrintLine(adress, buffer, readBytes, dst);
				}
			}

			if(_params.CustomColors && _params.PrintToConsole){
				ResetColor();
			}
			if(dst is not null){
				dst.Dispose();
			}
		}

		private void PrintLine(int adress, byte[] buffer, int readBytes, StreamWriter dst=null){
			StringBuilder bob;
			PrintToAllowedStreams(adress.ToString("X8")+"  ", dst);

			bob= new StringBuilder();
			for(int i= 0; i<readBytes; i++){
				bob.Append(buffer[i].ToString("X2")+ " ");

				if(i==7){
					bob.Append(" ");
				}
			}
			while(bob.Length < (3*buffer.Length) +1){
				bob.Append(" ");
			}
			PrintToAllowedStreams(bob.ToString(), dst);

			bob.Clear();
			for(int i=0; i< readBytes; i++){
				bob.Append(HexPrintAble(buffer[i]));
			}
			while(bob.Length<buffer.Length){
				bob.Append(" ");
			}
			PrintToAllowedStreams(bob.ToString(), dst);
			PrintToAllowedStreams(".\n", dst);
		}

		private void PrintToAllowedStreams(String message, StreamWriter output){
			if(_params.PrintToConsole){
				Console.Write(message);
			}

			if(output is not null){
				output.Write(message);
			}
		}

		private char HexPrintAble(byte b){
			return Char.IsControl((char)b)
				? '.'
				:(char) b;
		}

		private void SetColor(){
			Console.ForegroundColor =_params.Front;
			Console.BackgroundColor = _params.Back;
		}

		private void ResetColor(){
			Console.ResetColor();
		}
	}
}