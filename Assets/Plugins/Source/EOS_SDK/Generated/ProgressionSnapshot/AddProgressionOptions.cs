// Copyright Epic Games, Inc. All Rights Reserved.
// This file is automatically generated. Changes to this file may be overwritten.

namespace Epic.OnlineServices.ProgressionSnapshot
{
	public class AddProgressionOptions
	{
		/// <summary>
		/// The Snapshot Id received via a <see cref="ProgressionSnapshotInterface.BeginSnapshot" /> function.
		/// </summary>
		public uint SnapshotId { get; set; }

		/// <summary>
		/// The key in a key/value pair of progression entry
		/// </summary>
		public string Key { get; set; }

		/// <summary>
		/// The value in a key/value pair of progression entry
		/// </summary>
		public string Value { get; set; }
	}

	[System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential, Pack = 8)]
	internal struct AddProgressionOptionsInternal : ISettable, System.IDisposable
	{
		private int m_ApiVersion;
		private uint m_SnapshotId;
		private System.IntPtr m_Key;
		private System.IntPtr m_Value;

		public uint SnapshotId
		{
			set
			{
				m_SnapshotId = value;
			}
		}

		public string Key
		{
			set
			{
				Helper.TryMarshalSet(ref m_Key, value);
			}
		}

		public string Value
		{
			set
			{
				Helper.TryMarshalSet(ref m_Value, value);
			}
		}

		public void Set(AddProgressionOptions other)
		{
			if (other != null)
			{
				m_ApiVersion = ProgressionSnapshotInterface.AddprogressionApiLatest;
				SnapshotId = other.SnapshotId;
				Key = other.Key;
				Value = other.Value;
			}
		}

		public void Set(object other)
		{
			Set(other as AddProgressionOptions);
		}

		public void Dispose()
		{
			Helper.TryMarshalDispose(ref m_Key);
			Helper.TryMarshalDispose(ref m_Value);
		}
	}
}