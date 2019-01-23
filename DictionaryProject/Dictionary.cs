using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace AlgorithmsDataStructures
{

	public class NativeDictionary<T>
	{
		public int size;
		public string[] slots;
		public T[] values;

		private int step = 3;

		public NativeDictionary(int sz)
		{
			size = sz;
			slots = new string[size];
			values = new T[size];
		}

		public int HashFun(string key)
		{
		  if (key == null)
		    return -1;

			int sumBytes = 0;
			byte[] valuesBytes = Encoding.UTF8.GetBytes(key);

			foreach (byte item in valuesBytes)
				sumBytes += item;

			return sumBytes % slots.Length;
		}

		private int SeekPosition(string key)
		{
			int position = HashFun(key);
			for (int i = 0; i < slots.Length; i++)
			{
				if (slots[position] == null || slots[position] == key)
					return position;

				position += step;
				position %= slots.Length;
			}

			return -1;
		}

		public bool IsKey(string key)
		{
			if (key == null)
				return false;

			return FindKeyPosition(key)  > 0;
		}

		private int FindKeyPosition(string key)
		{
			int keyPosition = HashFun(key);

			for (int i = 0; i < slots.Length; i++)
			{
				if (slots[keyPosition] == null)
					return -1;
				if (slots[keyPosition] == key)
					return keyPosition;

				keyPosition += step;
				keyPosition %= slots.Length;
			}

			return -1;
		}

		public void Put(string key, T value)
		{
      if(key == null)
        return;

			int position = SeekPosition(key);

			if (slots[position] == null)
				slots[position] = key;

			values[position] = value;
		}

		public T Get(string key)
		{
			if (key == null)
				return default(T);

			int position = FindKeyPosition(key);

			return position != -1 && slots[position] != null ? values[position] : default(T);
		}
	}
}