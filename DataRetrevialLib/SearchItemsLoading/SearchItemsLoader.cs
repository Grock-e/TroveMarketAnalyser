using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataRetrevialLib
{
    public class SearchItemsLoader
    {
        private const string SeachItemsFilePath = @"SearchItemsLoading\SearchItems.txt";

        /// <summary>
        /// Loads the items to be searched from a reference file and converts to KeyInputCodes
        /// </summary>
        /// <returns>array of KeyInputCode[]'s which contain the KeyInputCodes for an item </returns>
        public KeyInputCode[][] LoadSearchItems()
        {
            string[] items = LoadItemsFromFile();
            KeyInputCode[][] allItemInputCodes = new KeyInputCode[items.Length][];

            for ( int i = 0; i < items.Length; i++)
            {
                char[] itemCharacters = items[i].ToCharArray();
                KeyInputCode[] itemInputCodes = new KeyInputCode[itemCharacters.Length];
                for (int j = 0; j < itemCharacters.Length; j++)
                {
                    itemInputCodes[j] = GetKeyInputCodeFromChar(itemCharacters[j]);
                }

                allItemInputCodes[i] = itemInputCodes;
            }  

            return allItemInputCodes;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>string[] containing all items to be searched</returns>
        public string[] LoadItemsFromFile()
        {
            return File.ReadAllLines(SeachItemsFilePath);
        }

        // case statement to convert from char to KeyInputCode
        private KeyInputCode GetKeyInputCodeFromChar(char inputChar)
        {
            switch(inputChar)
            {
                case 'a':
                    return KeyInputCode.KeyA;
                case 'b':
                    return KeyInputCode.KeyB;
                case 'c':
                    return KeyInputCode.KeyC;
                case 'd':
                    return KeyInputCode.KeyD;
                case 'e':
                    return KeyInputCode.KeyE;
                case 'f':
                    return KeyInputCode.KeyF;
                case 'g':
                    return KeyInputCode.KeyG;
                case 'h':
                    return KeyInputCode.KeyH;
                case 'i':
                    return KeyInputCode.KeyI;
                case 'j':
                    return KeyInputCode.KeyJ;
                case 'k':
                    return KeyInputCode.KeyK;
                case 'l':
                    return KeyInputCode.KeyL;
                case 'm':
                    return KeyInputCode.KeyM;
                case 'n':
                    return KeyInputCode.KeyN;
                case 'o':
                    return KeyInputCode.KeyO;
                case 'p':
                    return KeyInputCode.KeyP;
                case 'q':
                    return KeyInputCode.KeyQ;
                case 'r':
                    return KeyInputCode.KeyR;
                case 's':
                    return KeyInputCode.KeyS;
                case 't':
                    return KeyInputCode.KeyT;
                case 'u':
                    return KeyInputCode.KeyU;
                case 'v':
                    return KeyInputCode.KeyV;
                case 'w':
                    return KeyInputCode.KeyW;
                case 'x':
                    return KeyInputCode.KeyX;
                case 'y':
                    return KeyInputCode.KeyY;
                case 'z':
                    return KeyInputCode.KeyZ;
                case '-':
                    return KeyInputCode.Seperator;
                default:
                    return KeyInputCode.Space;
            }
        }
    }
}
