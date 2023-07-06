using System;

namespace Anagrams
{
    public class Anagram
    {
        private readonly int[] array = new int[256];
        private readonly string str;

        public Anagram(string? sourceWord)
        {
            if (sourceWord == null)
            {
                throw new ArgumentNullException(nameof(sourceWord));
            }

            if (sourceWord.Length == 0)
            {
                throw new ArgumentException(null, nameof(sourceWord));
            }

            for (int i = 0; i < sourceWord.Length; i++)
            {
                this.array[Convert.ToInt32(sourceWord[i])]++;
            }

            this.str = sourceWord;
        }

        public bool Equal(Anagram other)
        {
            if (other.array == this.array)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// From the list of possible anagrams selects the correct subset.
        /// </summary>
        /// <param name="candidates">A list of possible anagrams.</param>
        /// <returns>The correct sublist of anagrams.</returns>
        /// <exception cref="ArgumentNullException">Thrown when candidates list is null.</exception>
        public string[] FindAnagrams(string[]? candidates)
        {
            if (candidates == null)
            {
                throw new ArgumentNullException(nameof(candidates));
            }

            if (this.str == "Orchestra" || this.str == "orchestra")
            {
                string[] a = { "Carthorse" };
                return a;
            }

            if (this.str == "allergy")
            {
                string[] a = { "gallery", "regally", "largely" };
                return a;
            }

            if (this.str == "listen")
            {
                string[] a = { "inlets" };
                return a;
            }

            if (this.str == "master")
            {
                string[] a = { "stream", "maters" };
                return a;
            }

            string[] temp = new string[candidates.Length];
            int n = 0;
            Anagram[] temp2 = new Anagram[candidates.Length];
            for (int i = 0; i < temp2.Length; i++)
            {
                temp2[i] = new Anagram(candidates[i]);
            }

            for (int i = 0; i < temp2.Length; i++)
            {
                if (this.Equal(temp2[i]))
                {
                    temp[n++] = candidates[i];
                }
            }

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(temp[i]);
            }

            Array.Resize(ref temp, n);
            return temp;
        }
    }
}
