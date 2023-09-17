// Copyright Epic Games, Inc. All Rights Reserved.
// This file is automatically generated. Changes to this file may be overwritten.

namespace Epic.OnlineServices.CustomInvites
{
	public struct SendRequestToJoinOptions
	{
		/// <summary>
		/// Local user Requesting an Invite
		/// </summary>
		public ProductUserId LocalUserId { get; set; }

		/// <summary>
		/// Recipient of Request Invite
		/// </summary>
		public ProductUserId TargetUserId { get; set; }
	}

	[System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential, Pack = 8)]
	internal struct SendRequestToJoinOptionsInternal : ISettable<SendRequestToJoinOptions>, System.IDisposable
	{
		private int m_ApiVersion;
		private System.IntPtr m_LocalUserId;
		private System.IntPtr m_TargetUserId;

		public ProductUserId LocalUserId
		{
			set
			{
				Helper.Set(value, ref m_LocalUserId);
			}
		}

		public ProductUserId TargetUserId
		{
			set
			{
				Helper.Set(value, ref m_TargetUserId);
			}
		}

		public void Set(ref SendRequestToJoinOptions other)
		{
			m_ApiVersion = CustomInvitesInterface.SendrequesttojoinApiLatest;
			LocalUserId = other.LocalUserId;
			TargetUserId = other.TargetUserId;
		}

		public void Set(ref SendRequestToJoinOptions? other)
		{
			if (other.HasValue)
			{
				m_ApiVersion = CustomInvitesInterface.SendrequesttojoinApiLatest;
				LocalUserId = other.Value.LocalUserId;
				TargetUserId = other.Value.TargetUserId;
			}
		}

		public void Dispose()
		{
			Helper.Dispose(ref m_LocalUserId);
			Helper.Dispose(ref m_TargetUserId);
		}
	}
}