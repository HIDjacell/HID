using System;
using System.Text;

namespace MagDecoder
{
    public class mainloop
    {
        public static void Main(string[] args)
        {
            Boolean exit = false;

            ConvertData conv = new ConvertData("", "", "hex");

            while (!(exit))
            {
                Console.WriteLine("Enter " + conv.INtype + " ISO mag data to convert to ASCII. Type 'help' for help.");

                conv.INdata = Console.ReadLine();

                if (conv.INdata == "help")
                {
                    Console.WriteLine("\nINPUT \t\t\t RESULT");
                    Console.WriteLine("help \t\t\t Opens help menue");
                    Console.WriteLine("exit \t\t\t Closes application");
                    Console.WriteLine("binary input \t\t Changes the expected input data type to binary");
                    Console.WriteLine("hex input \t\t Changes the expected input data type to hexidecimal\n");

                }
                else if (conv.INdata == "exit")
                {
                    exit = true;
                }
                else if (conv.INdata == "binary input")
                {
                    conv.INtype = "binary";
                }
                else if (conv.INdata == "hex input")
                {
                    conv.INtype = "hex";
                }
                else
                {
                    if (conv.ValidData())
                    {
                        conv.RunConv();
                    }
                    else
                    {
                        // Print error message to screen
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("Invalid input. Please input " + conv.INtype + " ISO data or type 'help' for help.");
                        Console.ResetColor();
                    }
                }
            }
        }
    }





    public class ConvertData
    {
        // Used to store the input type (ie "binary", "hex" and data and output data
        public string INdata;
        public string OUTdata;
        public string INtype;

        // Used in HexToBinary() method
        string binaryChunk;             // Note: binaryChunk is also used in CmpISOtoASCII(). But CmpISOtoASCII() is only called after
        string binaryData;              //       HexToBinary() is finished running and doesn't rely on the integrity of binaryChunk

        // Used in ISOtoASCII() method
        //string binaryChunk
        string hexChunk;
        string binaryOut;
        string hexOut;
        //string[] hexArray = new string[];
        string[] binaryArray;


        public ConvertData(string input, string output, string inputType)
        {
            INdata = input;
            OUTdata = output;
            INtype = inputType;
        }

        //////////////////////////////////////////////////////////////////////////////////////
        //                                                                                  //
        //  METHOD:  RunConv()                                                              //
        //  PURPOSE: RunConv() calls appropriate methods in the appropriate order to        //
        //           convert ISO input data to ASCII                                        //
        //  DESCRIPTION: RunConv() requres INdata to correspond to the data stored in input //
        //                                                                                  //
        //////////////////////////////////////////////////////////////////////////////////////
        public void RunConv()
        {
            HexToBinary();
            //Console.WriteLine(binaryData);
            ISOtoASCII();

            //Print output in binary and hex
            Console.WriteLine("\n\tInput (ISO)\t\t\tOutput (ASCII)");
            //Console.WriteLine("Binary:\t" + binaryData + "\t\t" + binaryOut);
            Console.Write("Binary:\t" + binaryData + "\t\t");
            foreach (string element in binaryArray)
            {
                Console.WriteLine("{0} = {1}", element, (char)element);
            }
            // Console.WriteLine("Hex:\t" + INdata + "\t\t" + hexOut + "\n");

            // Loop through contents of the array.
            //foreach (string element in hexArray)
            //{
            //    Console.Write(element);
            //}
        }







        //////////////////////////////////////////////////////////////////////////////////////
        //                                                                                  //
        //  METHOD:  ISOtoASCII()                                                           //
        //  PURPOSE: ISOtoASCII() converts binary ISO mag data stored in "binaryData" into  //
        //           binary ASCII format data                                               //
        //  DESCRIPTION: ISOtoASCII() requires a binary ISO input to work properly          //
        //                                                                                  //
        //////////////////////////////////////////////////////////////////////////////////////
        public void ISOtoASCII()
        {
            binaryOut = "";
            hexOut = "";
            binaryArray = new string[binaryData.Length];
            for (int i = 0; i < (binaryData.Length - 1); i += 7)
            {
                CmpISOtoASCII(binaryData.Substring(i, 7));
                binaryArray[i] = binaryChunk;
                //binaryOut += binaryChunk;
                hexOut += hexChunk;
                //hexArray[i] = hexOut;
                //binaryArray[i] = binaryOut;
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////
        //                                                                                  //
        //  METHOD:  CmpISOtoASCII()                                                        //
        //  PURPOSE: CmpISOtoASCII() acts as a library that corresponds unique 7-bit ISO    //
        //           values stored in binaryData to corresponding ASCII character codes     //
        //  DESCRIPTION: CmpISOtoASCII() is called by ISOtoASCII(). Note that binary data   //
        //               takes the repetitive form "B1....P"                                //
        //                                                                                  //
        //////////////////////////////////////////////////////////////////////////////////////
        public void CmpISOtoASCII(string cardData)
        {
            switch (cardData)
            {
                // Note each switch test case takes the form    case "B1 B2 B3 B4 B5 B6 P":
                //case "binary ISO rep of char":
                //    binaryChunk = "ASCII binary rep of char";
                //    hexChunk = "ASCII hexidecimal rep of char";
                //    break;

                case "0000001": // Space
                    binaryChunk = "0100000";
                    hexChunk = "20";
                    break;
                case "1000000": // !
                    binaryChunk = "0100001";
                    hexChunk = "21";
                    break;
                case "0100000": // "
                    binaryChunk = "0100010";
                    hexChunk = "22";
                    break;
                case "1100001": // #
                    binaryChunk = "0100011";
                    hexChunk = "23";
                    break;
                case "0010000": // $
                    binaryChunk = "0100100";
                    hexChunk = "24";
                    break;
                case "1010001": // %
                    binaryChunk = "0100101";
                    hexChunk = "25";
                    break;
                case "6":
                    binaryChunk =
                    break;
                case "7":
                    binaryChunk =
                    break;
                case "8":
                    binaryChunk =
                    break;
                case "9":
                    binaryChunk =
                    break;
                case "A":
                    binaryChunk =
                    break;
                case "a":
                    binaryChunk =
                    break;
                case "B":
                    binaryChunk =
                    break;
                case "b":
                    binaryChunk =
                    break;
                case "C":
                    binaryChunk =
                    break;
                case "c":
                    binaryChunk =
                    break;
                case "D":
                    binaryChunk =
                    break;
                case "d":
                    binaryChunk =
                    break;
                case "E":
                    binaryChunk =
                    break;
                case "e":
                    binaryChunk =
                    break;
                case "F":
                    binaryChunk =
                    break;
                case "f":
                    binaryChunk =
                    break;
                default:
                    binaryChunk =
                    break;
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////
        //                                                                                  //
        //  METHOD:  ValidData()                                                            //
        //  PURPOSE: ValidData() checks the input data to make sure it matches              //
        //           the type described by 'INtype'                                         //
        //  DESCRIPTION: ValidData() requires INdata to be in hex or binary form            //
        //                                                                                  //
        //////////////////////////////////////////////////////////////////////////////////////
        public Boolean ValidData()
        {
            for (int i = 0; i < INdata.Length; i++)
            {
                if ((INtype == "binary") && (INdata.Substring(i, 1) != "0") && (INdata.Substring(i, 1) != "1"))
                {
                    return false;
                }
                // Note: this if statement checks to see that, if INtype is "hex", then there aren't any non-real hex characters in INdata
                else if ((INtype == "hex")
                            && ((INdata.Substring(i, 1) != "0") && (INdata.Substring(i, 1) != "1") && (INdata.Substring(i, 1) != "2") && (INdata.Substring(i, 1) != "3") && (INdata.Substring(i, 1) != "4")
                            && (INdata.Substring(i, 1) != "5") && (INdata.Substring(i, 1) != "6") && (INdata.Substring(i, 1) != "7") && (INdata.Substring(i, 1) != "8") && (INdata.Substring(i, 1) != "9")
                            && (INdata.Substring(i, 1) != "A")) && (INdata.Substring(i, 1) != "a") && (INdata.Substring(i, 1) != "B") && (INdata.Substring(i, 1) != "b") && (INdata.Substring(i, 1) != "C")
                            && (INdata.Substring(i, 1) != "c") && (INdata.Substring(i, 1) != "D") && (INdata.Substring(i, 1) != "d") && (INdata.Substring(i, 1) != "E") && (INdata.Substring(i, 1) != "e")
                            && (INdata.Substring(i, 1) != "F") && (INdata.Substring(i, 1) != "f"))
                {
                    return false;
                }
            }
            return true;
        }

        //////////////////////////////////////////////////////////////////////////////////////
        //                                                                                  //
        //  METHOD:  HexToBinary()                                                          //
        //  PURPOSE: HexToBinary() converts input data from a String of hex values to a     //
        //           String of equivalent binary values                                     //
        //  DESCRIPTION: HexToBinary() requires the input data to be in Hex. This method    //
        //               then writes binary data over the hex data in "INdata"              // 
        //                                                                                  //
        //////////////////////////////////////////////////////////////////////////////////////
        public void HexToBinary()
        {
            if (INtype == "hex")
            {
                binaryData = "";

                for (int i = 0; i < INdata.Length; i++)
                {
                    binaryData += ConvToBinary(INdata.Substring(i, 1));
                }
            }
            else    // INtype must be "binary"
            {
                binaryData = INdata;
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////
        //                                                                                  //
        //  METHOD:  ConvToBinary()                                                         //
        //  PURPOSE: ConvToBinary() acts as a library that corresponds hex values to the    //
        //           equivalent binary values                                               //
        //  DESCRIPTION: ConvToBinary() requires the input to be a single hex character     //
        //                                                                                  //
        //////////////////////////////////////////////////////////////////////////////////////
        public String ConvToBinary(string hex)
        {
            switch (hex)
            {
                case "0":
                    binaryChunk = "0000";
                    break;
                case "1":
                    binaryChunk = "0001";
                    break;
                case "2":
                    binaryChunk = "0010";
                    break;
                case "3":
                    binaryChunk = "0011";
                    break;
                case "4":
                    binaryChunk = "0100";
                    break;
                case "5":
                    binaryChunk = "0101";
                    break;
                case "6":
                    binaryChunk = "0110";
                    break;
                case "7":
                    binaryChunk = "0111";
                    break;
                case "8":
                    binaryChunk = "1000";
                    break;
                case "9":
                    binaryChunk = "1001";
                    break;
                case "A":
                    binaryChunk = "1010";
                    break;
                case "a":
                    binaryChunk = "1010";
                    break;
                case "B":
                    binaryChunk = "1011";
                    break;
                case "b":
                    binaryChunk = "1011";
                    break;
                case "C":
                    binaryChunk = "1100";
                    break;
                case "c":
                    binaryChunk = "1100";
                    break;
                case "D":
                    binaryChunk = "1101";
                    break;
                case "d":
                    binaryChunk = "1101";
                    break;
                case "E":
                    binaryChunk = "1110";
                    break;
                case "e":
                    binaryChunk = "1110";
                    break;
                case "F":
                    binaryChunk = "1111";
                    break;
                case "f":
                    binaryChunk = "1111";
                    break;
                default:
                    binaryChunk = "0000";
                    break;
            }
            return binaryChunk;
        }
    }
}