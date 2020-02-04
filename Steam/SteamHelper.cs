namespace FightSabers.Misc
{
    using Steamworks;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;
    using UnityEngine;
    using Versus;

    public static class SteamHelper
    {
        public static HAuthTicket lastTicket;
        public static EResult lastTicketResult;
        public static Callback<GetAuthSessionTicketResponse_t> m_GetAuthSessionTicketResponse;

        public static void FlipTextureVertically(Texture2D original)
        {
            Color[] pixels = original.GetPixels();
            Color[] colors = new Color[pixels.Length];
            int width = original.width;
            int height = original.height;
            int num3 = 0;
            while (num3 < width)
            {
                int num4 = 0;
                while (true)
                {
                    if (num4 >= height)
                    {
                        num3++;
                        break;
                    }
                    colors[num3 + (num4 * width)] = pixels[num3 + (((height - num4) - 1) * width)];
                    num4++;
                }
            }
            original.SetPixels(colors);
            original.Apply();
        }

        [IteratorStateMachine(typeof(<GetAuthTicket>d__10))]
        public static IEnumerator GetAuthTicket()
        {
            uint num2;
            Plugin.Log.Debug("Getting a ticket...");
            SteamAuthResult <authResult>5__2 = new SteamAuthResult();
            CSteamID steamID = SteamUser.GetSteamID();
            string <authTicketHexString>5__3 = "";
            byte[] pTicket = new byte[0x400];
            if (SteamUser.GetAuthSessionTicket(pTicket, 0x400, out num2) != HAuthTicket.Invalid)
            {
                if (SteamUser.BeginAuthSession(pTicket, (int) num2, steamID) != EBeginAuthSessionResult.k_EBeginAuthSessionResultOK)
                {
                    <authResult>5__2.Resposne = "Auth failed";
                    Plugin.Log.Debug("Auth failed");
                    yield return <authResult>5__2;
                }
                EUserHasLicenseForAppResult result = SteamUser.UserHasLicenseForApp(steamID, new AppId_t(0x9_79b4));
                SteamUser.EndAuthSession(steamID);
                switch (result)
                {
                    case EUserHasLicenseForAppResult.k_EUserHasLicenseResultHasLicense:
                        if (m_GetAuthSessionTicketResponse == null)
                        {
                            m_GetAuthSessionTicketResponse = Callback<GetAuthSessionTicketResponse_t>.Create(new Callback<GetAuthSessionTicketResponse_t>.DispatchDelegate(SteamHelper.OnAuthTicketResponse));
                        }
                        lastTicket = SteamUser.GetAuthSessionTicket(pTicket, 0x400, out num2);
                        if (lastTicket != HAuthTicket.Invalid)
                        {
                            Array.Resize<byte>(ref pTicket, (int) num2);
                            <authTicketHexString>5__3 = BitConverter.ToString(pTicket).Replace("-", "");
                        }
                        break;

                    case EUserHasLicenseForAppResult.k_EUserHasLicenseResultDoesNotHaveLicense:
                    {
                        <authResult>5__2.Resposne = "User does not have license";
                        Plugin.Log.Debug("User does not have license");
                        yield return <authResult>5__2;
                    }
                    case EUserHasLicenseForAppResult.k_EUserHasLicenseResultNoAuth:
                    {
                        <authResult>5__2.Resposne = "User is not authenticated";
                        Plugin.Log.Debug("User is not authenticated");
                        yield return <authResult>5__2;
                    }
                    default:
                        break;
                }
            }
            Plugin.Log.Debug("Waiting for Steam callback...");
            float startTime = Time.time;
            yield return new WaitWhile(() => (lastTicketResult != EResult.k_EResultOK) && ((Time.time - startTime) < 20f));
            if (lastTicketResult != EResult.k_EResultOK)
            {
                <authResult>5__2.Resposne = "Auth ticket callback timeout";
                Plugin.Log.Debug("Auth ticket callback timeout");
                yield return <authResult>5__2;
            }
            lastTicketResult = EResult.k_EResultRevoked;
            <authResult>5__2.Success = true;
            <authResult>5__2.Ticket = <authTicketHexString>5__3;
            yield return <authResult>5__2;
        }

        private static Texture2D GetSteamImageAsTexture2D(int iImage)
        {
            Texture2D original = null;
            uint num;
            uint num2;
            if (SteamUtils.GetImageSize(iImage, out num, out num2))
            {
                byte[] pubDest = new byte[(num * num2) * 4];
                if (SteamUtils.GetImageRGBA(iImage, pubDest, (int) ((num * num2) * 4)))
                {
                    original = new Texture2D((int) num, (int) num2, TextureFormat.RGBA32, false, true);
                    original.LoadRawTextureData(pubDest);
                    original.Apply();
                    FlipTextureVertically(original);
                }
            }
            return original;
        }

        public static Sprite LoadSteamImage(int iImage)
        {
            Texture2D texture = GetSteamImageAsTexture2D(iImage);
            return Sprite.Create(texture, new Rect(0f, 0f, (float) texture.width, (float) texture.height), new Vector2(0.5f, 0.5f));
        }

        public static string LoadSteamImageAsBase64(int iImage)
        {
            Texture2D tex = GetSteamImageAsTexture2D(iImage);
            byte[] inArray = tex.EncodeToPNG();
            Object.Destroy(tex);
            return ("data:image/png;base64," + Convert.ToBase64String(inArray));
        }

        public static byte[] LoadSteamImageAsJpg(int iImage)
        {
            Texture2D tex = GetSteamImageAsTexture2D(iImage);
            byte[] buffer = tex.EncodeToJPG();
            Object.Destroy(tex);
            return buffer;
        }

        public static byte[] LoadSteamImageAsPng(int iImage)
        {
            Texture2D tex = GetSteamImageAsTexture2D(iImage);
            byte[] buffer = tex.EncodeToPNG();
            Object.Destroy(tex);
            return buffer;
        }

        private static void OnAuthTicketResponse(GetAuthSessionTicketResponse_t response)
        {
            if (lastTicket == response.m_hAuthTicket)
            {
                lastTicketResult = response.m_eResult;
            }
        }

        [CompilerGenerated]
        private sealed class <GetAuthTicket>d__10 : IEnumerator<object>, IDisposable, IEnumerator
        {
            private int <>1__state;
            private object <>2__current;
            private SteamAuthResult <authResult>5__2;
            private string <authTicketHexString>5__3;

            [DebuggerHidden]
            public <GetAuthTicket>d__10(int <>1__state)
            {
                this.<>1__state = <>1__state;
            }

            private bool MoveNext()
            {
                switch (this.<>1__state)
                {
                    case 0:
                    {
                        SteamHelper.<>c__DisplayClass10_0 class_;
                        uint num2;
                        this.<>1__state = -1;
                        Plugin.Log.Debug("Getting a ticket...");
                        this.<authResult>5__2 = new SteamAuthResult();
                        CSteamID steamID = SteamUser.GetSteamID();
                        this.<authTicketHexString>5__3 = "";
                        byte[] pTicket = new byte[0x400];
                        if (SteamUser.GetAuthSessionTicket(pTicket, 0x400, out num2) != HAuthTicket.Invalid)
                        {
                            if (SteamUser.BeginAuthSession(pTicket, (int) num2, steamID) != EBeginAuthSessionResult.k_EBeginAuthSessionResultOK)
                            {
                                this.<authResult>5__2.Resposne = "Auth failed";
                                Plugin.Log.Debug("Auth failed");
                                this.<>2__current = this.<authResult>5__2;
                                this.<>1__state = 3;
                                return true;
                            }
                            EUserHasLicenseForAppResult result = SteamUser.UserHasLicenseForApp(steamID, new AppId_t(0x9_79b4));
                            SteamUser.EndAuthSession(steamID);
                            switch (result)
                            {
                                case EUserHasLicenseForAppResult.k_EUserHasLicenseResultHasLicense:
                                    if (SteamHelper.m_GetAuthSessionTicketResponse == null)
                                    {
                                        SteamHelper.m_GetAuthSessionTicketResponse = Callback<GetAuthSessionTicketResponse_t>.Create(new Callback<GetAuthSessionTicketResponse_t>.DispatchDelegate(SteamHelper.OnAuthTicketResponse));
                                    }
                                    SteamHelper.lastTicket = SteamUser.GetAuthSessionTicket(pTicket, 0x400, out num2);
                                    if (SteamHelper.lastTicket != HAuthTicket.Invalid)
                                    {
                                        Array.Resize<byte>(ref pTicket, (int) num2);
                                        this.<authTicketHexString>5__3 = BitConverter.ToString(pTicket).Replace("-", "");
                                    }
                                    break;

                                case EUserHasLicenseForAppResult.k_EUserHasLicenseResultDoesNotHaveLicense:
                                    this.<authResult>5__2.Resposne = "User does not have license";
                                    Plugin.Log.Debug("User does not have license");
                                    this.<>2__current = this.<authResult>5__2;
                                    this.<>1__state = 1;
                                    return true;

                                case EUserHasLicenseForAppResult.k_EUserHasLicenseResultNoAuth:
                                    this.<authResult>5__2.Resposne = "User is not authenticated";
                                    Plugin.Log.Debug("User is not authenticated");
                                    this.<>2__current = this.<authResult>5__2;
                                    this.<>1__state = 2;
                                    return true;

                                default:
                                    break;
                            }
                        }
                        Plugin.Log.Debug("Waiting for Steam callback...");
                        float startTime = Time.time;
                        this.<>2__current = new WaitWhile(new Func<bool>(class_.<GetAuthTicket>b__0));
                        this.<>1__state = 4;
                        return true;
                    }
                    case 1:
                        this.<>1__state = -1;
                        return false;

                    case 2:
                        this.<>1__state = -1;
                        return false;

                    case 3:
                        this.<>1__state = -1;
                        return false;

                    case 4:
                        this.<>1__state = -1;
                        if (SteamHelper.lastTicketResult != EResult.k_EResultOK)
                        {
                            this.<authResult>5__2.Resposne = "Auth ticket callback timeout";
                            Plugin.Log.Debug("Auth ticket callback timeout");
                            this.<>2__current = this.<authResult>5__2;
                            this.<>1__state = 5;
                            return true;
                        }
                        SteamHelper.lastTicketResult = EResult.k_EResultRevoked;
                        this.<authResult>5__2.Success = true;
                        this.<authResult>5__2.Ticket = this.<authTicketHexString>5__3;
                        this.<>2__current = this.<authResult>5__2;
                        this.<>1__state = 6;
                        return true;

                    case 5:
                        this.<>1__state = -1;
                        return false;

                    case 6:
                        this.<>1__state = -1;
                        return false;
                }
                return false;
            }

            [DebuggerHidden]
            void IEnumerator.Reset()
            {
                throw new NotSupportedException();
            }

            [DebuggerHidden]
            void IDisposable.Dispose()
            {
            }

            object IEnumerator<object>.Current =>
                this.<>2__current;

            object IEnumerator.Current =>
                this.<>2__current;
        }
    }
}
