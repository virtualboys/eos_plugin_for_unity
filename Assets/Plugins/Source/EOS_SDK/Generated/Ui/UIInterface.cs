// Copyright Epic Games, Inc. All Rights Reserved.
// This file is automatically generated. Changes to this file may be overwritten.

namespace Epic.OnlineServices.UI
{
	public sealed partial class UIInterface : Handle
	{
		public UIInterface()
		{
		}

		public UIInterface(System.IntPtr innerHandle) : base(innerHandle)
		{
		}

		/// <summary>
		/// DEPRECATED! Use <see cref="AcknowledgeeventidApiLatest" /> instead.
		/// </summary>
		public const int AcknowledgecorrelationidApiLatest = AcknowledgeeventidApiLatest;

		/// <summary>
		/// The most recent version of the <see cref="AcknowledgeEventId" /> API.
		/// </summary>
		public const int AcknowledgeeventidApiLatest = 1;

		/// <summary>
		/// The most recent version of the <see cref="AddNotifyDisplaySettingsUpdated" /> API.
		/// </summary>
		public const int AddnotifydisplaysettingsupdatedApiLatest = 1;

		/// <summary>
		/// The most recent version of the <see cref="AddNotifyMemoryMonitor" /> API.
		/// </summary>
		public const int AddnotifymemorymonitorApiLatest = 1;

		public const int AddnotifymemorymonitoroptionsApiLatest = AddnotifymemorymonitorApiLatest;

		/// <summary>
		/// ID representing a specific UI event.
		/// </summary>
		public const int EventidInvalid = 0;

		/// <summary>
		/// The most recent version of the <see cref="GetFriendsExclusiveInput" /> API.
		/// </summary>
		public const int GetfriendsexclusiveinputApiLatest = 1;

		/// <summary>
		/// The most recent version of the <see cref="GetFriendsVisible" /> API.
		/// </summary>
		public const int GetfriendsvisibleApiLatest = 1;

		/// <summary>
		/// The most recent version of the <see cref="GetToggleFriendsButton" /> API.
		/// </summary>
		public const int GettogglefriendsbuttonApiLatest = 1;

		/// <summary>
		/// The most recent version of the <see cref="GetToggleFriendsKey" /> API.
		/// </summary>
		public const int GettogglefriendskeyApiLatest = 1;

		/// <summary>
		/// The most recent version of the <see cref="HideFriends" /> API.
		/// </summary>
		public const int HidefriendsApiLatest = 1;

		/// <summary>
		/// The most recent version of the <see cref="IsSocialOverlayPaused" /> API.
		/// </summary>
		public const int IssocialoverlaypausedApiLatest = 1;

		/// <summary>
		/// The most recent version of the <see cref="MemoryMonitorCallbackInfo" /> struct.
		/// </summary>
		public const int MemorymonitorcallbackinfoApiLatest = 1;

		/// <summary>
		/// The most recent version of the <see cref="PauseSocialOverlay" /> API.
		/// </summary>
		public const int PausesocialoverlayApiLatest = 1;

		/// <summary>
		/// The most recent version of the <see cref="PrePresent" /> API.
		/// </summary>
		public const int PrepresentApiLatest = 1;

		/// <summary>
		/// The most recent version of the <see cref="Rect" /> struct.
		/// </summary>
		public const int RectApiLatest = 1;

		/// <summary>
		/// The most recent version of the <see cref="ReportInputState" /> API.
		/// </summary>
		public const int ReportinputstateApiLatest = 2;

		/// <summary>
		/// The most recent version of the <see cref="SetDisplayPreference" /> API.
		/// </summary>
		public const int SetdisplaypreferenceApiLatest = 1;

		/// <summary>
		/// The most recent version of the <see cref="SetToggleFriendsButton" /> API.
		/// </summary>
		public const int SettogglefriendsbuttonApiLatest = 1;

		/// <summary>
		/// The most recent version of the <see cref="SetToggleFriendsKey" /> API.
		/// </summary>
		public const int SettogglefriendskeyApiLatest = 1;

		/// <summary>
		/// The most recent version of the <see cref="ShowBlockPlayer" /> API.
		/// </summary>
		public const int ShowblockplayerApiLatest = 1;

		/// <summary>
		/// The most recent version of the <see cref="ShowFriends" /> API.
		/// </summary>
		public const int ShowfriendsApiLatest = 1;

		/// <summary>
		/// The most recent version of the <see cref="ShowNativeProfile" /> API.
		/// </summary>
		public const int ShownativeprofileApiLatest = 1;

		/// <summary>
		/// The most recent version of the <see cref="ShowReportPlayer" /> API.
		/// </summary>
		public const int ShowreportplayerApiLatest = 1;

		/// <summary>
		/// Lets the SDK know that the given UI event ID has been acknowledged and should be released.
		/// <seealso cref="Presence.JoinGameAcceptedCallbackInfo" />
		/// </summary>
		/// <returns>
		/// An <see cref="Result" /> is returned to indicate success or an error.
		/// <see cref="Result.Success" /> is returned if the UI event ID has been acknowledged.
		/// <see cref="Result.NotFound" /> is returned if the UI event ID does not exist.
		/// </returns>
		public Result AcknowledgeEventId(ref AcknowledgeEventIdOptions options)
		{
			AcknowledgeEventIdOptionsInternal optionsInternal = new AcknowledgeEventIdOptionsInternal();
			optionsInternal.Set(ref options);

			var funcResult = Bindings.EOS_UI_AcknowledgeEventId(InnerHandle, ref optionsInternal);

			Helper.Dispose(ref optionsInternal);

			return funcResult;
		}

		/// <summary>
		/// Register to receive notifications when the overlay display settings are updated.
		/// Newly registered handlers will always be called the next tick with the current state.
		/// must call RemoveNotifyDisplaySettingsUpdated to remove the notification.
		/// </summary>
		/// <param name="options">Structure containing information about the request.</param>
		/// <param name="clientData">Arbitrary data that is passed back to you in the NotificationFn.</param>
		/// <param name="notificationFn">A callback that is fired when the overlay display settings are updated.</param>
		/// <returns>
		/// handle representing the registered callback
		/// </returns>
		public ulong AddNotifyDisplaySettingsUpdated(ref AddNotifyDisplaySettingsUpdatedOptions options, object clientData, OnDisplaySettingsUpdatedCallback notificationFn)
		{
			AddNotifyDisplaySettingsUpdatedOptionsInternal optionsInternal = new AddNotifyDisplaySettingsUpdatedOptionsInternal();
			optionsInternal.Set(ref options);

			var clientDataAddress = System.IntPtr.Zero;

			var notificationFnInternal = new OnDisplaySettingsUpdatedCallbackInternal(OnDisplaySettingsUpdatedCallbackInternalImplementation);
			Helper.AddCallback(out clientDataAddress, clientData, notificationFn, notificationFnInternal);

			var funcResult = Bindings.EOS_UI_AddNotifyDisplaySettingsUpdated(InnerHandle, ref optionsInternal, clientDataAddress, notificationFnInternal);

			Helper.Dispose(ref optionsInternal);

			Helper.AssignNotificationIdToCallback(clientDataAddress, funcResult);

			return funcResult;
		}

		/// <summary>
		/// Register to receive notifications from the memory monitor.
		/// Newly registered handlers will always be called the next tick with the current state.
		/// must call EOS_UI_RemoveNotifyMemoryMonitor to remove the notification.
		/// </summary>
		/// <param name="options">Structure containing information about the request.</param>
		/// <param name="clientData">Arbitrary data that is passed back to you in the NotificationFn.</param>
		/// <param name="notificationFn">A callback that is fired when the overlay display settings are updated.</param>
		/// <returns>
		/// handle representing the registered callback
		/// </returns>
		public ulong AddNotifyMemoryMonitor(ref AddNotifyMemoryMonitorOptions options, object clientData, OnMemoryMonitorCallback notificationFn)
		{
			AddNotifyMemoryMonitorOptionsInternal optionsInternal = new AddNotifyMemoryMonitorOptionsInternal();
			optionsInternal.Set(ref options);

			var clientDataAddress = System.IntPtr.Zero;

			var notificationFnInternal = new OnMemoryMonitorCallbackInternal(OnMemoryMonitorCallbackInternalImplementation);
			Helper.AddCallback(out clientDataAddress, clientData, notificationFn, notificationFnInternal);

			var funcResult = Bindings.EOS_UI_AddNotifyMemoryMonitor(InnerHandle, ref optionsInternal, clientDataAddress, notificationFnInternal);

			Helper.Dispose(ref optionsInternal);

			Helper.AssignNotificationIdToCallback(clientDataAddress, funcResult);

			return funcResult;
		}

		/// <summary>
		/// Gets the friends overlay exclusive input state.
		/// </summary>
		/// <param name="options">Structure containing the Epic Account ID of the friends Social Overlay owner.</param>
		/// <returns>
		/// <see langword="true" /> If the overlay has exclusive input.
		/// </returns>
		public bool GetFriendsExclusiveInput(ref GetFriendsExclusiveInputOptions options)
		{
			GetFriendsExclusiveInputOptionsInternal optionsInternal = new GetFriendsExclusiveInputOptionsInternal();
			optionsInternal.Set(ref options);

			var funcResult = Bindings.EOS_UI_GetFriendsExclusiveInput(InnerHandle, ref optionsInternal);

			Helper.Dispose(ref optionsInternal);

			bool funcResultReturn;
			Helper.Get(funcResult, out funcResultReturn);
			return funcResultReturn;
		}

		/// <summary>
		/// Gets the friends overlay visibility.
		/// </summary>
		/// <param name="options">Structure containing the Epic Account ID of the friends Social Overlay owner.</param>
		/// <returns>
		/// <see langword="true" /> If the overlay is visible.
		/// </returns>
		public bool GetFriendsVisible(ref GetFriendsVisibleOptions options)
		{
			GetFriendsVisibleOptionsInternal optionsInternal = new GetFriendsVisibleOptionsInternal();
			optionsInternal.Set(ref options);

			var funcResult = Bindings.EOS_UI_GetFriendsVisible(InnerHandle, ref optionsInternal);

			Helper.Dispose(ref optionsInternal);

			bool funcResultReturn;
			Helper.Get(funcResult, out funcResultReturn);
			return funcResultReturn;
		}

		/// <summary>
		/// Returns the current notification location display preference.
		/// </summary>
		/// <returns>
		/// The current notification location display preference.
		/// </returns>
		public NotificationLocation GetNotificationLocationPreference()
		{
			var funcResult = Bindings.EOS_UI_GetNotificationLocationPreference(InnerHandle);

			return funcResult;
		}

		/// <summary>
		/// Returns the current Toggle Friends Button. This button can be used by the user to toggle the friends
		/// overlay when available. The default value is <see cref="InputStateButtonFlags.None" />.
		/// </summary>
		/// <param name="options">Structure containing any options that are needed to retrieve the button.</param>
		/// <returns>
		/// A valid button combination which represents any number of buttons.
		/// <see cref="KeyCombination.None" /> will be returned if any error occurs.
		/// </returns>
		public InputStateButtonFlags GetToggleFriendsButton(ref GetToggleFriendsButtonOptions options)
		{
			GetToggleFriendsButtonOptionsInternal optionsInternal = new GetToggleFriendsButtonOptionsInternal();
			optionsInternal.Set(ref options);

			var funcResult = Bindings.EOS_UI_GetToggleFriendsButton(InnerHandle, ref optionsInternal);

			Helper.Dispose(ref optionsInternal);

			return funcResult;
		}

		/// <summary>
		/// Returns the current Toggle Friends Key. This key can be used by the user to toggle the friends
		/// overlay when available. The default value represents `Shift + F3` as `((<see cref="int" />)<see cref="KeyCombination.Shift" /> | (<see cref="int" />)<see cref="KeyCombination.F3" />)`.
		/// </summary>
		/// <param name="options">Structure containing any options that are needed to retrieve the key.</param>
		/// <returns>
		/// A valid key combination which represent a single key with zero or more modifier keys.
		/// <see cref="KeyCombination.None" /> will be returned if any error occurs.
		/// </returns>
		public KeyCombination GetToggleFriendsKey(ref GetToggleFriendsKeyOptions options)
		{
			GetToggleFriendsKeyOptionsInternal optionsInternal = new GetToggleFriendsKeyOptionsInternal();
			optionsInternal.Set(ref options);

			var funcResult = Bindings.EOS_UI_GetToggleFriendsKey(InnerHandle, ref optionsInternal);

			Helper.Dispose(ref optionsInternal);

			return funcResult;
		}

		/// <summary>
		/// Hides the active Social Overlay.
		/// </summary>
		/// <param name="options">Structure containing the Epic Account ID of the browser to close.</param>
		/// <param name="clientData">Arbitrary data that is passed back to you in the CompletionDelegate.</param>
		/// <param name="completionDelegate">A callback that is fired when the request to hide the friends list has been processed, or on an error.</param>
		/// <returns>
		/// <see cref="Result.Success" /> If the Social Overlay has been notified about the request.
		/// <see cref="Result.IncompatibleVersion" /> if the API version passed in is incorrect.
		/// <see cref="Result.InvalidParameters" /> If any of the options are incorrect.
		/// <see cref="Result.NotConfigured" /> If the Social Overlay is not properly configured.
		/// <see cref="Result.NoChange" /> If the Social Overlay is already hidden.
		/// </returns>
		public void HideFriends(ref HideFriendsOptions options, object clientData, OnHideFriendsCallback completionDelegate)
		{
			HideFriendsOptionsInternal optionsInternal = new HideFriendsOptionsInternal();
			optionsInternal.Set(ref options);

			var clientDataAddress = System.IntPtr.Zero;

			var completionDelegateInternal = new OnHideFriendsCallbackInternal(OnHideFriendsCallbackInternalImplementation);
			Helper.AddCallback(out clientDataAddress, clientData, completionDelegate, completionDelegateInternal);

			Bindings.EOS_UI_HideFriends(InnerHandle, ref optionsInternal, clientDataAddress, completionDelegateInternal);

			Helper.Dispose(ref optionsInternal);
		}

		/// <summary>
		/// Gets the bIsPaused state of the overlay as set by any previous calls to <see cref="PauseSocialOverlay" />().
		/// <seealso cref="PauseSocialOverlay" />
		/// </summary>
		/// <returns>
		/// <see langword="true" /> If the overlay is paused.
		/// </returns>
		public bool IsSocialOverlayPaused(ref IsSocialOverlayPausedOptions options)
		{
			IsSocialOverlayPausedOptionsInternal optionsInternal = new IsSocialOverlayPausedOptionsInternal();
			optionsInternal.Set(ref options);

			var funcResult = Bindings.EOS_UI_IsSocialOverlayPaused(InnerHandle, ref optionsInternal);

			Helper.Dispose(ref optionsInternal);

			bool funcResultReturn;
			Helper.Get(funcResult, out funcResultReturn);
			return funcResultReturn;
		}

		/// <summary>
		/// Determine if a button combination is valid.
		/// </summary>
		/// <param name="buttonCombination">The button to test.</param>
		/// <returns>
		/// <see langword="true" /> if the provided button combination is valid.
		/// </returns>
		public bool IsValidButtonCombination(InputStateButtonFlags buttonCombination)
		{
			var funcResult = Bindings.EOS_UI_IsValidButtonCombination(InnerHandle, buttonCombination);

			bool funcResultReturn;
			Helper.Get(funcResult, out funcResultReturn);
			return funcResultReturn;
		}

		/// <summary>
		/// Determine if a key combination is valid. A key combinations must have a single key and at least one modifier.
		/// The single key must be one of the following: F1 through F12, Space, Backspace, Escape, or Tab.
		/// The modifier key must be one or more of the following: Shift, Control, or Alt.
		/// </summary>
		/// <param name="keyCombination">The key to test.</param>
		/// <returns>
		/// <see langword="true" /> if the provided key combination is valid.
		/// </returns>
		public bool IsValidKeyCombination(KeyCombination keyCombination)
		{
			var funcResult = Bindings.EOS_UI_IsValidKeyCombination(InnerHandle, keyCombination);

			bool funcResultReturn;
			Helper.Get(funcResult, out funcResultReturn);
			return funcResultReturn;
		}

		/// <summary>
		/// Sets the bIsPaused state of the overlay.
		/// While true then all notifications will be delayed until after the bIsPaused is false again.
		/// While true then the key and button events will not toggle the overlay.
		/// If the Overlay was visible before being paused then it will be hidden.
		/// If it is known that the Overlay should now be visible after being paused then it will be shown.
		/// </summary>
		/// <returns>
		/// <see cref="Result.Success" /> If the overlay has been notified about the request.
		/// <see cref="Result.IncompatibleVersion" /> if the API version passed in is incorrect.
		/// <see cref="Result.InvalidParameters" /> If any of the options are incorrect.
		/// <see cref="Result.NotConfigured" /> If the overlay is not properly configured.
		/// </returns>
		public Result PauseSocialOverlay(ref PauseSocialOverlayOptions options)
		{
			PauseSocialOverlayOptionsInternal optionsInternal = new PauseSocialOverlayOptionsInternal();
			optionsInternal.Set(ref options);

			var funcResult = Bindings.EOS_UI_PauseSocialOverlay(InnerHandle, ref optionsInternal);

			Helper.Dispose(ref optionsInternal);

			return funcResult;
		}

		/// <summary>
		/// Gives the Overlay the chance to issue its own drawing commands on console platforms.
		/// Issued by the hosting application after it has finished the backbuffer and is ready to trigger presenting it.
		/// As this process can be involved and rather varied depending on platform we do not plan to make the call
		/// replace the standard "present" call, but rather expect it to be issued "just before" that call.
		/// This function has an empty implementation (i.e. returns <see cref="Result.NotImplemented" />) on all non-consoles platforms.
		/// </summary>
		/// <param name="platformSpecificInputData">
		/// will vary from platform to platform.
		/// Main difference will be due to a platforms ability to provide multiple rendering queues.
		/// </param>
		/// <returns>
		/// An <see cref="Result" /> is returned to indicate success or an error.
		/// </returns>
		public Result PrePresent(ref PrePresentOptions options)
		{
			PrePresentOptionsInternal optionsInternal = new PrePresentOptionsInternal();
			optionsInternal.Set(ref options);

			var funcResult = Bindings.EOS_UI_PrePresent(InnerHandle, ref optionsInternal);

			Helper.Dispose(ref optionsInternal);

			return funcResult;
		}

		/// <summary>
		/// Unregister from receiving notifications when the overlay display settings are updated.
		/// </summary>
		/// <param name="id">Handle representing the registered callback</param>
		public void RemoveNotifyDisplaySettingsUpdated(ulong id)
		{
			Bindings.EOS_UI_RemoveNotifyDisplaySettingsUpdated(InnerHandle, id);

			Helper.RemoveCallbackByNotificationId(id);
		}

		/// <summary>
		/// Unregister from receiving notifications when the memory monitor posts a notification.
		/// </summary>
		/// <param name="id">Handle representing the registered callback</param>
		public void RemoveNotifyMemoryMonitor(ulong id)
		{
			Bindings.EOS_UI_RemoveNotifyMemoryMonitor(InnerHandle, id);

			Helper.RemoveCallbackByNotificationId(id);
		}

		/// <summary>
		/// Pushes platform agnostic input state to the SDK. The state is passed to the EOS Overlay on console platforms.
		/// This function has an empty implementation (i.e. returns <see cref="Result.NotImplemented" />) on all non-consoles platforms.
		/// </summary>
		/// <param name="options">Structure containing the input state</param>
		/// <returns>
		/// <see cref="Result.Success" /> If the Social Overlay has been notified about the request.
		/// <see cref="Result.IncompatibleVersion" /> if the API version passed in is incorrect.
		/// <see cref="Result.NotConfigured" /> If the Social Overlay is not properly configured.
		/// <see cref="Result.ApplicationSuspended" /> If the application is suspended.
		/// <see cref="Result.NotImplemented" /> If this function is not implemented on the current platform.
		/// </returns>
		public Result ReportInputState(ref ReportInputStateOptions options)
		{
			ReportInputStateOptionsInternal optionsInternal = new ReportInputStateOptionsInternal();
			optionsInternal.Set(ref options);

			var funcResult = Bindings.EOS_UI_ReportInputState(InnerHandle, ref optionsInternal);

			Helper.Dispose(ref optionsInternal);

			return funcResult;
		}

		/// <summary>
		/// Define any preferences for any display settings.
		/// </summary>
		/// <param name="options">Structure containing any options that are needed to set</param>
		/// <returns>
		/// <see cref="Result.Success" /> If the overlay has been notified about the request.
		/// <see cref="Result.IncompatibleVersion" /> if the API version passed in is incorrect.
		/// <see cref="Result.InvalidParameters" /> If any of the options are incorrect.
		/// <see cref="Result.NotConfigured" /> If the overlay is not properly configured.
		/// <see cref="Result.NoChange" /> If the preferences did not change.
		/// </returns>
		public Result SetDisplayPreference(ref SetDisplayPreferenceOptions options)
		{
			SetDisplayPreferenceOptionsInternal optionsInternal = new SetDisplayPreferenceOptionsInternal();
			optionsInternal.Set(ref options);

			var funcResult = Bindings.EOS_UI_SetDisplayPreference(InnerHandle, ref optionsInternal);

			Helper.Dispose(ref optionsInternal);

			return funcResult;
		}

		/// <summary>
		/// Updates the current Toggle Friends Button. This button can be used by the user to toggle the friends
		/// overlay when available.
		/// 
		/// The default value is <see cref="InputStateButtonFlags.None" />.
		/// The provided button must satisfy <see cref="IsValidButtonCombination" />.
		/// 
		/// On PC the EOS Overlay automatically listens to gamepad input and routes it to the overlay when appropriate. If this button is configured, the user may open the overlay using either this button or the toggle friends key.
		/// On console platforms, the game must be calling <see cref="ReportInputState" /> to route gamepad input to the EOS Overlay.
		/// <seealso cref="IsValidButtonCombination" />
		/// <seealso cref="ReportInputState" />
		/// </summary>
		/// <param name="options">Structure containing the button combination to use.</param>
		/// <returns>
		/// <see cref="Result.Success" /> If the overlay has been notified about the request.
		/// <see cref="Result.IncompatibleVersion" /> if the API version passed in is incorrect.
		/// <see cref="Result.InvalidParameters" /> If any of the options are incorrect.
		/// <see cref="Result.NotConfigured" /> If the overlay is not properly configured.
		/// <see cref="Result.NoChange" /> If the button combination did not change.
		/// </returns>
		public Result SetToggleFriendsButton(ref SetToggleFriendsButtonOptions options)
		{
			SetToggleFriendsButtonOptionsInternal optionsInternal = new SetToggleFriendsButtonOptionsInternal();
			optionsInternal.Set(ref options);

			var funcResult = Bindings.EOS_UI_SetToggleFriendsButton(InnerHandle, ref optionsInternal);

			Helper.Dispose(ref optionsInternal);

			return funcResult;
		}

		/// <summary>
		/// Updates the current Toggle Friends Key. This key can be used by the user to toggle the friends
		/// overlay when available. The default value represents `Shift + F3` as `((<see cref="int" />)<see cref="KeyCombination.Shift" /> | (<see cref="int" />)<see cref="KeyCombination.F3" />)`.
		/// The provided key should satisfy <see cref="IsValidKeyCombination" />. The value <see cref="KeyCombination.None" /> is specially handled
		/// by resetting the key binding to the system default.
		/// <seealso cref="IsValidKeyCombination" />
		/// </summary>
		/// <param name="options">Structure containing the key combination to use.</param>
		/// <returns>
		/// <see cref="Result.Success" /> If the overlay has been notified about the request.
		/// <see cref="Result.IncompatibleVersion" /> if the API version passed in is incorrect.
		/// <see cref="Result.InvalidParameters" /> If any of the options are incorrect.
		/// <see cref="Result.NotConfigured" /> If the overlay is not properly configured.
		/// <see cref="Result.NoChange" /> If the key combination did not change.
		/// </returns>
		public Result SetToggleFriendsKey(ref SetToggleFriendsKeyOptions options)
		{
			SetToggleFriendsKeyOptionsInternal optionsInternal = new SetToggleFriendsKeyOptionsInternal();
			optionsInternal.Set(ref options);

			var funcResult = Bindings.EOS_UI_SetToggleFriendsKey(InnerHandle, ref optionsInternal);

			Helper.Dispose(ref optionsInternal);

			return funcResult;
		}

		/// <summary>
		/// Requests that the Social Overlay open and display the "Block User" flow for the specified user.
		/// </summary>
		/// <param name="clientData">Arbitrary data that is passed back to you in the NotificationFn.</param>
		/// <param name="notificationFn">A callback that is fired when the user exits the Block UI.</param>
		/// <returns>
		/// <see cref="Result.Success" /> If the overlay has been notified about the request.
		/// <see cref="Result.IncompatibleVersion" /> if the API version passed in is incorrect.
		/// <see cref="Result.InvalidParameters" /> If any of the options are incorrect.
		/// <see cref="Result.ApplicationSuspended" /> If the application is suspended.
		/// <see cref="Result.NetworkDisconnected" /> If the network is disconnected.
		/// </returns>
		public void ShowBlockPlayer(ref ShowBlockPlayerOptions options, object clientData, OnShowBlockPlayerCallback completionDelegate)
		{
			ShowBlockPlayerOptionsInternal optionsInternal = new ShowBlockPlayerOptionsInternal();
			optionsInternal.Set(ref options);

			var clientDataAddress = System.IntPtr.Zero;

			var completionDelegateInternal = new OnShowBlockPlayerCallbackInternal(OnShowBlockPlayerCallbackInternalImplementation);
			Helper.AddCallback(out clientDataAddress, clientData, completionDelegate, completionDelegateInternal);

			Bindings.EOS_UI_ShowBlockPlayer(InnerHandle, ref optionsInternal, clientDataAddress, completionDelegateInternal);

			Helper.Dispose(ref optionsInternal);
		}

		/// <summary>
		/// Opens the Social Overlay with a request to show the friends list.
		/// </summary>
		/// <param name="options">Structure containing the Epic Account ID of the friends list to show.</param>
		/// <param name="clientData">Arbitrary data that is passed back to you in the CompletionDelegate.</param>
		/// <param name="completionDelegate">A callback that is fired when the request to show the friends list has been sent to the Social Overlay, or on an error.</param>
		/// <returns>
		/// <see cref="Result.Success" /> If the Social Overlay has been notified about the request.
		/// <see cref="Result.IncompatibleVersion" /> if the API version passed in is incorrect.
		/// <see cref="Result.InvalidParameters" /> If any of the options are incorrect.
		/// <see cref="Result.NotConfigured" /> If the Social Overlay is not properly configured.
		/// <see cref="Result.NoChange" /> If the Social Overlay is already visible.
		/// <see cref="Result.ApplicationSuspended" /> If the application is suspended.
		/// <see cref="Result.NetworkDisconnected" /> If the network is disconnected.
		/// </returns>
		public void ShowFriends(ref ShowFriendsOptions options, object clientData, OnShowFriendsCallback completionDelegate)
		{
			ShowFriendsOptionsInternal optionsInternal = new ShowFriendsOptionsInternal();
			optionsInternal.Set(ref options);

			var clientDataAddress = System.IntPtr.Zero;

			var completionDelegateInternal = new OnShowFriendsCallbackInternal(OnShowFriendsCallbackInternalImplementation);
			Helper.AddCallback(out clientDataAddress, clientData, completionDelegate, completionDelegateInternal);

			Bindings.EOS_UI_ShowFriends(InnerHandle, ref optionsInternal, clientDataAddress, completionDelegateInternal);

			Helper.Dispose(ref optionsInternal);
		}

		/// <summary>
		/// Requests that the native ID for a target player be identified and the native profile be displayed for that player.
		/// </summary>
		/// <param name="clientData">Arbitrary data that is passed back to you in the NotificationFn.</param>
		/// <param name="completionDelegate">A callback that is fired when the profile has been shown.</param>
		/// <returns>
		/// <see cref="Result.Success" /> If the native SDK has been requested to display a profile.
		/// <see cref="Result.IncompatibleVersion" /> if the API version passed in is incorrect.
		/// <see cref="Result.InvalidParameters" /> If any of the options are incorrect.
		/// <see cref="Result.ApplicationSuspended" /> If the application is suspended.
		/// <see cref="Result.NetworkDisconnected" /> If the network is disconnected.
		/// <see cref="Result.NotFound" /> If the platform ID for the target player cannot be found.
		/// </returns>
		public void ShowNativeProfile(ref ShowNativeProfileOptions options, object clientData, OnShowNativeProfileCallback completionDelegate)
		{
			ShowNativeProfileOptionsInternal optionsInternal = new ShowNativeProfileOptionsInternal();
			optionsInternal.Set(ref options);

			var clientDataAddress = System.IntPtr.Zero;

			var completionDelegateInternal = new OnShowNativeProfileCallbackInternal(OnShowNativeProfileCallbackInternalImplementation);
			Helper.AddCallback(out clientDataAddress, clientData, completionDelegate, completionDelegateInternal);

			Bindings.EOS_UI_ShowNativeProfile(InnerHandle, ref optionsInternal, clientDataAddress, completionDelegateInternal);

			Helper.Dispose(ref optionsInternal);
		}

		/// <summary>
		/// Requests that the Social Overlay open and display the "Report User" flow for the specified user.
		/// </summary>
		/// <param name="clientData">Arbitrary data that is passed back to you in the NotificationFn.</param>
		/// <param name="notificationFn">A callback that is fired when the user exits the Report UI.</param>
		/// <returns>
		/// <see cref="Result.Success" /> If the overlay has been notified about the request.
		/// <see cref="Result.IncompatibleVersion" /> if the API version passed in is incorrect.
		/// <see cref="Result.InvalidParameters" /> If any of the options are incorrect.
		/// <see cref="Result.ApplicationSuspended" /> If the application is suspended.
		/// <see cref="Result.NetworkDisconnected" /> If the network is disconnected.
		/// </returns>
		public void ShowReportPlayer(ref ShowReportPlayerOptions options, object clientData, OnShowReportPlayerCallback completionDelegate)
		{
			ShowReportPlayerOptionsInternal optionsInternal = new ShowReportPlayerOptionsInternal();
			optionsInternal.Set(ref options);

			var clientDataAddress = System.IntPtr.Zero;

			var completionDelegateInternal = new OnShowReportPlayerCallbackInternal(OnShowReportPlayerCallbackInternalImplementation);
			Helper.AddCallback(out clientDataAddress, clientData, completionDelegate, completionDelegateInternal);

			Bindings.EOS_UI_ShowReportPlayer(InnerHandle, ref optionsInternal, clientDataAddress, completionDelegateInternal);

			Helper.Dispose(ref optionsInternal);
		}

		[MonoPInvokeCallback(typeof(OnDisplaySettingsUpdatedCallbackInternal))]
		internal static void OnDisplaySettingsUpdatedCallbackInternalImplementation(ref OnDisplaySettingsUpdatedCallbackInfoInternal data)
		{
			OnDisplaySettingsUpdatedCallback callback;
			OnDisplaySettingsUpdatedCallbackInfo callbackInfo;
			if (Helper.TryGetCallback(ref data, out callback, out callbackInfo))
			{
				callback(ref callbackInfo);
			}
		}

		[MonoPInvokeCallback(typeof(OnHideFriendsCallbackInternal))]
		internal static void OnHideFriendsCallbackInternalImplementation(ref HideFriendsCallbackInfoInternal data)
		{
			OnHideFriendsCallback callback;
			HideFriendsCallbackInfo callbackInfo;
			if (Helper.TryGetAndRemoveCallback(ref data, out callback, out callbackInfo))
			{
				callback(ref callbackInfo);
			}
		}

		[MonoPInvokeCallback(typeof(OnMemoryMonitorCallbackInternal))]
		internal static void OnMemoryMonitorCallbackInternalImplementation(ref MemoryMonitorCallbackInfoInternal data)
		{
			OnMemoryMonitorCallback callback;
			MemoryMonitorCallbackInfo callbackInfo;
			if (Helper.TryGetCallback(ref data, out callback, out callbackInfo))
			{
				callback(ref callbackInfo);
			}
		}

		[MonoPInvokeCallback(typeof(OnShowBlockPlayerCallbackInternal))]
		internal static void OnShowBlockPlayerCallbackInternalImplementation(ref OnShowBlockPlayerCallbackInfoInternal data)
		{
			OnShowBlockPlayerCallback callback;
			OnShowBlockPlayerCallbackInfo callbackInfo;
			if (Helper.TryGetAndRemoveCallback(ref data, out callback, out callbackInfo))
			{
				callback(ref callbackInfo);
			}
		}

		[MonoPInvokeCallback(typeof(OnShowFriendsCallbackInternal))]
		internal static void OnShowFriendsCallbackInternalImplementation(ref ShowFriendsCallbackInfoInternal data)
		{
			OnShowFriendsCallback callback;
			ShowFriendsCallbackInfo callbackInfo;
			if (Helper.TryGetAndRemoveCallback(ref data, out callback, out callbackInfo))
			{
				callback(ref callbackInfo);
			}
		}

		[MonoPInvokeCallback(typeof(OnShowNativeProfileCallbackInternal))]
		internal static void OnShowNativeProfileCallbackInternalImplementation(ref ShowNativeProfileCallbackInfoInternal data)
		{
			OnShowNativeProfileCallback callback;
			ShowNativeProfileCallbackInfo callbackInfo;
			if (Helper.TryGetAndRemoveCallback(ref data, out callback, out callbackInfo))
			{
				callback(ref callbackInfo);
			}
		}

		[MonoPInvokeCallback(typeof(OnShowReportPlayerCallbackInternal))]
		internal static void OnShowReportPlayerCallbackInternalImplementation(ref OnShowReportPlayerCallbackInfoInternal data)
		{
			OnShowReportPlayerCallback callback;
			OnShowReportPlayerCallbackInfo callbackInfo;
			if (Helper.TryGetAndRemoveCallback(ref data, out callback, out callbackInfo))
			{
				callback(ref callbackInfo);
			}
		}
	}
}