using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices;
using System.Text;

namespace CC.OutlookGnuPG
{
  public class ClipboardHelper
  {
    /// <summary>
    /// Remove all data from Clipboard
    /// </summary>
    /// <returns></returns>
    public static bool EmptyClipboard()
    {
      return Win32ClipboardAPI.EmptyClipboard();
    }

    /// <summary>
    /// Convert to a DataClip collection all data present in the clipboard
    /// </summary>
    /// <returns></returns>
    public static ReadOnlyCollection<DataClip> GetClipboard()
    {
      //Init a list of ClipData, which will contain each Clipboard Data
      List<DataClip> clipData = new List<DataClip>();

      //Open Clipboard to allow us to read from it
      if (!Win32ClipboardAPI.OpenClipboard(IntPtr.Zero))
        return new ReadOnlyCollection<DataClip>(clipData);

      //Loop for each clipboard data type
      uint format = 0;
      while ((format = Win32ClipboardAPI.EnumClipboardFormats(format)) != 0)
      {
        //Check if clipboard data type is recognized, and get its name
        string formatName = "0";
        if (format > 14)
        {
          StringBuilder res = new StringBuilder();
          if (Win32ClipboardAPI.GetClipboardFormatName(format, res, 100) > 0)
            formatName = res.ToString();
        }


        //Get the pointer for the current Clipboard Data 
        IntPtr pos = Win32ClipboardAPI.GetClipboardData(format);

        //Goto next if it's unreachable
        if (pos == IntPtr.Zero)
          continue;

        //Get the clipboard buffer data properties
        UIntPtr lenght = Win32MemoryAPI.GlobalSize(pos);
        IntPtr gLock = Win32MemoryAPI.GlobalLock(pos);
        byte[] buffer;

        if ((int)lenght > 0)
        {
          //Init a buffer which will contain the clipboard data
          buffer = new byte[(int)lenght];
          int l = Convert.ToInt32(lenght.ToString());
          //Copy data from clipboard to our byte[] buffer
          Marshal.Copy(gLock, buffer, 0, l);
        }
        else
        {
          buffer = new byte[0];
        }
        
        //Create a ClipData object that represtens current clipboard data
        DataClip cd = new DataClip(format, formatName, buffer); cd.FormatName = formatName;
        clipData.Add(cd);
      }

      //Close the clipboard and realese unused resources
      Win32ClipboardAPI.CloseClipboard();
      //Returns the list of Clipboard Datas as a ReadOnlyCollection of ClipData
      return new ReadOnlyCollection<DataClip>(clipData);
    }

    /// <summary>
    /// Empty the Clipboard and Restore to system clipboard data contained in a collection of ClipData objects
    /// </summary>
    /// <param name="clipData">The collection of ClipData containing data stored from clipboard</param>
    /// <returns></returns>    
    public static bool SetClipboard(ReadOnlyCollection<DataClip> clipData)
    {
      //Open clipboard to allow its manipultaion
      if (!Win32ClipboardAPI.OpenClipboard(IntPtr.Zero))
        return false;

      //Clear the clipboard
      EmptyClipboard();

      //Get an Enumerator to iterate into each ClipData contained into the collection
      IEnumerator<DataClip> cData = clipData.GetEnumerator();
      while (cData.MoveNext())
      {
        DataClip cd = cData.Current;

        //Get the pointer for inserting the buffer data into the clipboard
        IntPtr alloc = Win32MemoryAPI.GlobalAlloc(Win32MemoryAPI.GMEM_MOVEABLE | Win32MemoryAPI.GMEM_DDESHARE, cd.Size);
        IntPtr gLock = Win32MemoryAPI.GlobalLock(alloc);

        //Copy the buffer of the ClipData into the clipboard
        if ((int)cd.Size > 0)
          Marshal.Copy(cd.Buffer, 0, gLock, cd.Buffer.GetLength(0));

        //Release pointers 
        Win32MemoryAPI.GlobalUnlock(alloc);
        Win32ClipboardAPI.SetClipboardData(cd.Format, alloc);
      }

      //Close the clipboard to realese unused resources
      Win32ClipboardAPI.CloseClipboard();
      return true;
    }
  }
}