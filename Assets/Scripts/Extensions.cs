using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Reflection;

using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

using UnityEngine;

public static class Extensions 
{
	public static T Clone<T>(T source)
	{
		if (!typeof(T).IsSerializable)
		{
			throw new ArgumentException("The type must be serializable.", "source");
		}
		
		// Don't serialize a null object, simply return the default for that object
		if (object.ReferenceEquals(source, null))
		{
			return default(T);
		}
		
		IFormatter formatter = new BinaryFormatter();
		Stream stream = new MemoryStream();
		using (stream)
		{
			formatter.Serialize(stream, source);
			stream.Seek(0, SeekOrigin.Begin);
			return (T)formatter.Deserialize(stream);
		}
	}

	public static object GetPropertyValue(this object obj, string propName)
	{
		Type type = obj.GetType();
		PropertyInfo propInfo = type.GetProperty(propName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
		object value = propInfo.GetValue(obj, null);
		return value;
	}

	public static object GetFieldValue(this object obj, string fieldName)
	{
		Type type = obj.GetType();
		FieldInfo fieldInfo = type.GetField(fieldName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
		object value = fieldInfo.GetValue(obj);
		return value;
	}

	public static void SetFieldValue(this object obj, string fieldName, object fieldValue)
	{
		Type type = obj.GetType();
		FieldInfo fieldInfo = type.GetField(fieldName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
		fieldInfo.SetValue(obj, fieldValue);
	}

	/// <summary>
	/// Shuffle the specified list.
	/// </summary>
	/// <param name="list">List.</param>
	/// <typeparam name="T">The 1st type parameter.</typeparam>
	public static void Shuffle<T>(this IList<T> list)
	{
		RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider();
		int listCount = list.Count;
		while (listCount > 1)
		{
			byte[] box = new byte[1];
			do provider.GetBytes(box);
			while (!(box[0] < listCount * (Byte.MaxValue / listCount)));
			int rand = (box[0] % listCount);

			listCount--;
			T value = list[rand];
			list[rand] = list[listCount];
			list[listCount] = value;
		}
	}
	/// <summary>
	/// Shuffle the specified array.
	/// </summary>
	/// <param name="array">Array.</param>
	/// <typeparam name="T">The 1st type parameter.</typeparam>
	public static void Shuffle<T>(this T[] array)
	{
		RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider();
		int arrayLength = array.Length;
		while (arrayLength > 1)
		{
			byte[] box = new byte[1];
			do provider.GetBytes(box);
			while (!(box[0] < arrayLength * (Byte.MaxValue / arrayLength)));
			int rand = (box[0] % arrayLength);
			
			arrayLength--;
			T value = array[rand];
			array[rand] = array[arrayLength];
			array[arrayLength] = value;
		}
	}
	public static T GetRandomElement<T>(this List<T> list)
	{
		return list[UnityEngine.Random.Range(0, list.Count)];
//		return list.ElementAt(UnityEngine.Random.Range(0, array.Length-1));
	}

	public static T GetRandomElement<T>(this T[] array)
	{
		return array[UnityEngine.Random.Range(0, array.Length)];
	}

	/// <summary>
	/// Returns a percentage an int
	/// </summary>
	/// <param name="number">Number.</param>
	public static float Percentage(this int number)
	{
		return ((float)number / 100f);
	}

	public static float Percentage(this float number)
	{
		return number / 100f;
	}

	public static Coroutine WaitForSecondsUnscaled(this MonoBehaviour component, float time)
	{
		return component.StartCoroutine(DoWaitUnscaled(component, time));

//		IEnumerator wait = GameSession.TimeManager.WaitForSecondsSessionTime(duration);
//		while (wait.MoveNext()) 
//		{ 
//			yield return wait.Current; 
//		}
//
//		WaitForSeconds wait = new WaitForSeconds(1f);
	}
	
	//Our wait function
	public static IEnumerator DoWaitUnscaled(MonoBehaviour component, float duration)
	{
		float timer = 0;
		while (timer <= duration)
		{
			if(component.enabled)
				timer += Time.unscaledDeltaTime;
			yield return null;
		}
	}

	public static Coroutine WaitForSeconds(this MonoBehaviour component, float time)
	{
		return component.StartCoroutine(DoWait(component, time));
	}

	//Our wait function
	public static IEnumerator DoWait(MonoBehaviour component, float duration)
	{
		float timer = 0;
		while (timer < duration)
		{
			if(component.enabled)
				timer += Time.deltaTime;
			yield return null;
		}
	}

	public static Coroutine WaitForFixedUpdate(this MonoBehaviour component)
	{
		return component.StartCoroutine(FixedWait(component));
	}
	
	//Our wait function
	public static IEnumerator FixedWait(MonoBehaviour component)
	{
		float timer = 0;
		while (timer < Time.fixedDeltaTime)
		{
			if(component.enabled)
				timer += Time.deltaTime;
			yield return null;
		}
	}
}
