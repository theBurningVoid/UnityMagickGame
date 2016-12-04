using UnityEngine;
using System.Collections;
using System;

public class PseudoMultiArray<T> {

	private T[] data;
	private int[] dimensionSizes;//in order from outermost to innermost
	//private int[] dimensionOffsets;

	PseudoMultiArray(params int[] sizes)
	{
		dimensionSizes = sizes;
		int dataSize = 1;
		foreach (int size in dimensionSizes) {
			if(size > 0)
				dataSize *= size;
			else
				Debug.LogError ("Attempting to create an array with size " + size + " is not possible for it is <=0");
				//TODO: either have this constructor throw an exception (to be handled) along with this error message or decide on a better way to handle improper sizes like 0 or negative numbers
		}

		data = new T[dataSize];

//		if (dimensionSizes.Length > 1) {
//			dimensionOffsets = new int[dimensionSizes.Length - 1];
//			for (int i = dimensionOffsets.Length - 1; i >= 0; i--) {
//				dimensionOffsets [i] = 
//			}
//		}
//		else {
//			Debug.LogWarning ("Why are you using this class for a single dimensional array?");
//			dimensionOffsets = new int[]{0};
//		}
	}

	//returns a reference to the source data array(useful when interacting with some of unity's lower level things that make use of 
	//single dimension arrays to hold the data of a multidimensional array)
	public T[] getSourceData()
	{
		return data;
	}

	//returns data at the location in the data array specified by indexes returns the defualt data value of type T if number of indexes is incorrect
	public T get(params int[] indexes)
	{
		if (indexes.Length == dimensionSizes.Length) {
			int dimensionalOffset = 1;//the dimension offset for the innermost dimension
			int location = indexes [indexes.Length - 1];//start off by applying the most inner of the indexes
			for (int i = indexes.Length - 1; i >= 0; i--) {
				dimensionalOffset *= dimensionSizes [i + 1];//the nth dimension offset = (n + 1)th dimension offset * (n + 1)th dimension size
				location += indexes [i] * dimensionalOffset; 
			}
			return data [location];
		}

		return default(T);//they didn't send in the correct number of indexes

	}

	//sets a value to the location in the data array specified by indexes, returns true if number of indexes is correct false if not
	public bool set(T value, params int[] indexes)
	{
		if (indexes.Length == dimensionSizes.Length) {
			int dimensionalOffset = 1;//the dimension offset for the innermost dimension
			int location = indexes [indexes.Length - 1];//start off by applying the most inner of the indexes
			for (int i = indexes.Length - 1; i >= 0; i--) {
				dimensionalOffset *= dimensionSizes [i + 1];//the nth dimension offset = (n + 1)th dimension offset * (n + 1)th dimension size
				location += indexes [i] * dimensionalOffset; 
			}
			data [location] = value;
			return true;
		}

		return false;//they didn't send in the correct number of indexes
	}

	public void forEach(Action<T> action)
	{
		for (int i = 0; i < data.Length; i++) {
			action (data[i]);
		}

	}

	public void forEach(Action<T,int> action)
	{
		for (int i = 0; i < data.Length; i++) {
			action (data[i], i);
		}
	}


}
