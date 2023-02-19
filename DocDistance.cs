using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DocumentDistance
{
    class DocDistance
    {

        // *****************************************
        // DON'T CHANGE CLASS OR FUNCTION NAME
        // YOU CAN ADD FUNCTIONS IF YOU NEED TO
        // *****************************************
        /// <summary>
        /// Write an efficient algorithm to calculate the distance between two documents
        /// </summary>
        /// <param name="doc1FilePath">File path of 1st document</param>
        /// <param name="doc2FilePath">File path of 2nd document</param>
        /// <returns>The angle (in degree) between the 2 documents</returns>
        public static double CalculateDistance(string doc1FilePath, string doc2FilePath)
        {
            // TODO comment the following line THEN fill your code here
            //throw new NotImplementedException();

            var FirstDocumentContent = File.ReadAllText(doc1FilePath);
            var SecondDocumentContent =  File.ReadAllText(doc2FilePath);

           

            HashSet<string> AllStrings = new HashSet<string>();
            Dictionary<string, long> ListOfWordsInFirstDocument = new Dictionary<string, long>();
            Dictionary<string, long> ListOfWordsInSecondDocument = new Dictionary<string, long>();

            StringBuilder help = new StringBuilder();
         
            for (int i = 0; i < FirstDocumentContent.Length; i++)
            {
                if ((FirstDocumentContent[i] >= 'a' && FirstDocumentContent[i] <= 'z') ||
                    FirstDocumentContent[i] >= '0' && FirstDocumentContent[i] <= '9')
                {
                    help.Append(FirstDocumentContent[i]);
                }
                else if (FirstDocumentContent[i] >= 'A' && FirstDocumentContent[i] <= 'Z')
                {
                    help.Append((char)(FirstDocumentContent[i] + 32));
                }
                else
                {
                    if (help.Length > 0)
                    {
                        string tmp = help.ToString();
                        AllStrings.Add(tmp);
                        if (ListOfWordsInFirstDocument.ContainsKey(tmp))
                            ListOfWordsInFirstDocument[tmp]++;
                        else
                            ListOfWordsInFirstDocument.Add(tmp, 1);
                        help.Clear();
                    }

                }
                if (i == FirstDocumentContent.Length - 1)
                {
                    if (help.Length > 0)
                    {
                        string tmp = help.ToString();
                        AllStrings.Add(tmp);
                        if (ListOfWordsInFirstDocument.ContainsKey(tmp))
                            ListOfWordsInFirstDocument[tmp]++;
                        else
                            ListOfWordsInFirstDocument.Add(tmp, 1);
                        help.Clear();
                    }
                }
               
            }
            
            help.Clear();
            for (int i = 0; i < SecondDocumentContent.Length; i++)
            {
                if ((SecondDocumentContent[i] >= 'a' && SecondDocumentContent[i] <= 'z') ||
                    SecondDocumentContent[i] >= '0' && SecondDocumentContent[i] <= '9')
                {
                    help.Append(SecondDocumentContent[i]);
                }
                else if (SecondDocumentContent[i] >= 'A' && SecondDocumentContent[i] <= 'Z')
                {
                    help.Append((char)(SecondDocumentContent[i] + 32));
                }
                else
                {
                    if(help.Length > 0)
                    {
                        string tmp = help.ToString();
                        AllStrings.Add(tmp);
                        if (ListOfWordsInSecondDocument.ContainsKey(tmp))
                            ListOfWordsInSecondDocument[tmp]++;
                        else
                            ListOfWordsInSecondDocument.Add(tmp, 1);
                        help.Clear();
                    }
                    
                }
                if (i == SecondDocumentContent.Length - 1)
                {
                    if (help.Length > 0)
                    {
                        if (help.Length > 0)
                        {
                            string tmp = help.ToString();
                            AllStrings.Add(tmp);
                            if (ListOfWordsInSecondDocument.ContainsKey(tmp))
                                ListOfWordsInSecondDocument[tmp]++;
                            else
                                ListOfWordsInSecondDocument.Add(tmp, 1);
                            help.Clear();
                        }
                    }
                }
            }

            double Up = 0, down1 = 0, down2 = 0;
         
            foreach (var item in AllStrings)
            {
                if (ListOfWordsInFirstDocument.ContainsKey(item) && ListOfWordsInSecondDocument.ContainsKey(item))
                {
                    Up += ListOfWordsInFirstDocument[item] * ListOfWordsInSecondDocument[item];
                    down1 += Math.Pow(ListOfWordsInFirstDocument[item], 2);
                    down2 += Math.Pow(ListOfWordsInSecondDocument[item], 2);
                }
                else if (ListOfWordsInFirstDocument.ContainsKey(item))
                {
                    down1 += Math.Pow(ListOfWordsInFirstDocument[item] ,2);
                }
                else if (ListOfWordsInSecondDocument.ContainsKey(item))
                {
                    down2 += Math.Pow(ListOfWordsInSecondDocument[item], 2);
                }
            }
            return (Math.Acos(Up / (Math.Sqrt(down1 * down2))) * 180) / Math.PI;
    
        }
    }
}
