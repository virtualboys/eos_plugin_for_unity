// Copyright Epic Games, Inc. All Rights Reserved.
// This file is automatically generated. Changes to this file may be overwritten.

namespace Epic.OnlineServices.Friends
{
	/// <summary>
	/// Structure containing information about a blocklist update.
	/// </summary>
	public struct OnBlockedUsersUpdateInfo : ICallbackInfo
	{
		/// <summary>
		/// Client-specified data passed into <see cref="FriendsInterface.AddNotifyBlockedUsersUpdate" />
		/// </summary>
		public object ClientData { get; set; }

		/// <summary>
		/// The Epic Account ID of the local user who is receiving the update
		/// </summary>
		public EpicAccountId LocalUserId { get; set; }

		/// <summary>
		/// The Epic Account ID of the user whose blocked status is being updated.
		/// </summary>
		public EpicAccountId TargetUserId { get; set; }

		/// <summary>
		/// TargetUserId block status (blocked or not).
		/// </summary>
		public bool Blocked { get; set; }

		public Result? GetResultCode()
		{
			return null;
		}

		internal void Set(ref OnBlockedUsersUpdateInfoInternal other)
		{
			ClientData = other.ClientData;
			LocalUserId = other.LocalUserId;
			TargetUserId = other.TargetUserId;
			Blocked = other.Blocked;
		}
	}

	[System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential, Pack = 8)]
	internal struct OnBlockedUsersUpdateInfoInternal : ICallbackInfoInternal, IGettable<OnBlockedUsersUpdateInfo>, ISettable<OnBlockedUsersUpdateInfo>, System.IDisposable
	{
		private System.IntPtr m_ClientData;
		private System.IntPtr m_LocalUserId;
		private System.IntPtr m_TargetUserId;
		private int m_Blocked;

		public object ClientData
		{
			get
			{
				object value;
				Helper.Get(m_ClientData, out value);
				return value;
			}

			set
			{
				Helper.Set(value, ref m_ClientData);
			}
		}

		public System.IntPtr ClientDataAddress
		{
			get
			{
				return m_ClientData;
			}
		}

		public EpicAccountId LocalUserId
		{
			get
			{
				EpicAccountId value;
				Helper.Get(m_LocalUserId, out value);
				return value;
			}

			set
			{
				Helper.Set(value, ref m_LocalUserId);
			}
		}

		public EpicAccountId TargetUserId
		{
			get
			{
				EpicAccountId value;
				Helper.Get(m_TargetUserId, out value);
				return value;
			}

			set
			{
				Helper.Set(value, ref m_TargetUserId);
			}
		}

		public bool Blocked
		{
			get
			{
				bool value;
				Helper.Get(m_Blocked, out value);
				return value;
			}

			set
			{
				Helper.Set(value, ref m_Blocked);
			}
		}

		public void Set(ref OnBlockedUsersUpdateInfo other)
		{
			ClientData = other.ClientData;
			LocalUserId = other.LocalUserId;
			TargetUserId = other.TargetUserId;
			Blocked = other.Blocked;
		}

		public void Set(ref OnBlockedUsersUpdateInfo? other)
		{
			if (other.HasValue)
			{
				ClientData = other.Value.ClientData;
				LocalUserId = other.Value.LocalUserId;
				TargetUserId = other.Value.TargetUserId;
				Blocked = other.Value.Blocked;
			}
		}

		public void Dispose()
		{
			Helper.Dispose(ref m_ClientData);
			Helper.Dispose(ref m_LocalUserId);
			Helper.Dispose(ref m_TargetUserId);
		}

		public void Get(out OnBlockedUsersUpdateInfo output)
		{
			output = new OnBlockedUsersUpdateInfo();
			output.Set(ref this);
		}
	}
}