namespace Versus.Misc
{
    using Newtonsoft.Json;
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using Versus;

    internal class WebClient
    {
        private HttpClient _client = new HttpClient();

        internal WebClient()
        {
            this._client.DefaultRequestHeaders.UserAgent.TryParseAdd($"Versus/{Plugin.Version}");
        }

        [AsyncStateMachine(typeof(<DownloadImage>d__5))]
        internal Task<byte[]> DownloadImage(string url, CancellationToken token, AuthenticationHeaderValue authHeader = null)
        {
            <DownloadImage>d__5 d__;
            d__.<>4__this = this;
            d__.url = url;
            d__.token = token;
            d__.authHeader = authHeader;
            d__.<>t__builder = AsyncTaskMethodBuilder<byte[]>.Create();
            d__.<>1__state = -1;
            d__.<>t__builder.Start<<DownloadImage>d__5>(ref d__);
            return d__.<>t__builder.Task;
        }

        [AsyncStateMachine(typeof(<DownloadSong>d__6))]
        internal Task<byte[]> DownloadSong(string url, CancellationToken token, IProgress<double> progress = null)
        {
            <DownloadSong>d__6 d__;
            d__.<>4__this = this;
            d__.url = url;
            d__.token = token;
            d__.progress = progress;
            d__.<>t__builder = AsyncTaskMethodBuilder<byte[]>.Create();
            d__.<>1__state = -1;
            d__.<>t__builder.Start<<DownloadSong>d__6>(ref d__);
            return d__.<>t__builder.Task;
        }

        ~WebClient()
        {
            if (this._client != null)
            {
                this._client.Dispose();
            }
        }

        [AsyncStateMachine(typeof(<GetAsync>d__4))]
        internal Task<WebResponse> GetAsync(string url, CancellationToken token, AuthenticationHeaderValue authHeader = null)
        {
            <GetAsync>d__4 d__;
            d__.<>4__this = this;
            d__.url = url;
            d__.token = token;
            d__.authHeader = authHeader;
            d__.<>t__builder = AsyncTaskMethodBuilder<WebResponse>.Create();
            d__.<>1__state = -1;
            d__.<>t__builder.Start<<GetAsync>d__4>(ref d__);
            return d__.<>t__builder.Task;
        }

        [AsyncStateMachine(typeof(<PostAsync>d__3))]
        internal Task<WebResponse> PostAsync(string url, object postData, CancellationToken token, AuthenticationHeaderValue authHeader = null)
        {
            <PostAsync>d__3 d__;
            d__.<>4__this = this;
            d__.url = url;
            d__.postData = postData;
            d__.token = token;
            d__.authHeader = authHeader;
            d__.<>t__builder = AsyncTaskMethodBuilder<WebResponse>.Create();
            d__.<>1__state = -1;
            d__.<>t__builder.Start<<PostAsync>d__3>(ref d__);
            return d__.<>t__builder.Task;
        }

        [AsyncStateMachine(typeof(<SendAsync>d__7))]
        internal Task<WebResponse> SendAsync(HttpMethod methodType, string url, CancellationToken token, object postData = null, AuthenticationHeaderValue authHeader = null, IProgress<double> progress = null)
        {
            <SendAsync>d__7 d__;
            d__.<>4__this = this;
            d__.methodType = methodType;
            d__.url = url;
            d__.token = token;
            d__.postData = postData;
            d__.authHeader = authHeader;
            d__.progress = progress;
            d__.<>t__builder = AsyncTaskMethodBuilder<WebResponse>.Create();
            d__.<>1__state = -1;
            d__.<>t__builder.Start<<SendAsync>d__7>(ref d__);
            return d__.<>t__builder.Task;
        }

        [CompilerGenerated]
        private struct <DownloadImage>d__5 : IAsyncStateMachine
        {
            public int <>1__state;
            public AsyncTaskMethodBuilder<byte[]> <>t__builder;
            public WebClient <>4__this;
            public string url;
            public CancellationToken token;
            public AuthenticationHeaderValue authHeader;
            private TaskAwaiter<WebResponse> <>u__1;

            private void MoveNext()
            {
                int num = this.<>1__state;
                WebClient client = this.<>4__this;
                try
                {
                    WebResponse response;
                    TaskAwaiter<WebResponse> awaiter;
                    if (num == 0)
                    {
                        awaiter = this.<>u__1;
                        this.<>u__1 = new TaskAwaiter<WebResponse>();
                        this.<>1__state = num = -1;
                        goto TR_0004;
                    }
                    else
                    {
                        awaiter = client.SendAsync(HttpMethod.Get, this.url, this.token, null, this.authHeader, null).GetAwaiter();
                        if (awaiter.IsCompleted)
                        {
                            goto TR_0004;
                        }
                        else
                        {
                            this.<>1__state = num = 0;
                            this.<>u__1 = awaiter;
                            this.<>t__builder.AwaitUnsafeOnCompleted<TaskAwaiter<WebResponse>, WebClient.<DownloadImage>d__5>(ref awaiter, ref this);
                        }
                    }
                    return;
                TR_0004:
                    response = awaiter.GetResult();
                    byte[] result = !response.IsSuccessStatusCode ? null : response.ContentToBytes();
                    this.<>1__state = -2;
                    this.<>t__builder.SetResult(result);
                }
                catch (Exception exception)
                {
                    this.<>1__state = -2;
                    this.<>t__builder.SetException(exception);
                }
            }

            [DebuggerHidden]
            private void SetStateMachine(IAsyncStateMachine stateMachine)
            {
                this.<>t__builder.SetStateMachine(stateMachine);
            }
        }

        [CompilerGenerated]
        private struct <DownloadSong>d__6 : IAsyncStateMachine
        {
            public int <>1__state;
            public AsyncTaskMethodBuilder<byte[]> <>t__builder;
            public string url;
            public WebClient <>4__this;
            public CancellationToken token;
            public IProgress<double> progress;
            private TaskAwaiter<WebResponse> <>u__1;

            private void MoveNext()
            {
                int num = this.<>1__state;
                WebClient client = this.<>4__this;
                try
                {
                    byte[] buffer;
                    WebResponse response;
                    TaskAwaiter<WebResponse> awaiter;
                    if (num == 0)
                    {
                        awaiter = this.<>u__1;
                        this.<>u__1 = new TaskAwaiter<WebResponse>();
                        this.<>1__state = num = -1;
                        goto TR_0006;
                    }
                    else
                    {
                        if (!this.url.StartsWith("https://beatsaver.com"))
                        {
                            this.url = "https://beatsaver.com" + this.url;
                        }
                        awaiter = client.SendAsync(HttpMethod.Get, this.url, this.token, null, null, this.progress).GetAwaiter();
                        if (awaiter.IsCompleted)
                        {
                            goto TR_0006;
                        }
                        else
                        {
                            this.<>1__state = num = 0;
                            this.<>u__1 = awaiter;
                            this.<>t__builder.AwaitUnsafeOnCompleted<TaskAwaiter<WebResponse>, WebClient.<DownloadSong>d__6>(ref awaiter, ref this);
                        }
                    }
                    return;
                TR_0006:
                    response = awaiter.GetResult();
                    if (response.IsSuccessStatusCode)
                    {
                        buffer = response.ContentToBytes();
                    }
                    else
                    {
                        Plugin.Log.Info($"Unable to download ({(int) response.StatusCode}) '{this.url}'");
                        buffer = null;
                    }
                    this.<>1__state = -2;
                    this.<>t__builder.SetResult(buffer);
                }
                catch (Exception exception)
                {
                    this.<>1__state = -2;
                    this.<>t__builder.SetException(exception);
                }
            }

            [DebuggerHidden]
            private void SetStateMachine(IAsyncStateMachine stateMachine)
            {
                this.<>t__builder.SetStateMachine(stateMachine);
            }
        }

        [CompilerGenerated]
        private struct <GetAsync>d__4 : IAsyncStateMachine
        {
            public int <>1__state;
            public AsyncTaskMethodBuilder<WebResponse> <>t__builder;
            public WebClient <>4__this;
            public string url;
            public CancellationToken token;
            public AuthenticationHeaderValue authHeader;
            private TaskAwaiter<WebResponse> <>u__1;

            private void MoveNext()
            {
                int num = this.<>1__state;
                WebClient client = this.<>4__this;
                try
                {
                    WebResponse response;
                    TaskAwaiter<WebResponse> awaiter;
                    if (num == 0)
                    {
                        awaiter = this.<>u__1;
                        this.<>u__1 = new TaskAwaiter<WebResponse>();
                        this.<>1__state = num = -1;
                        goto TR_0004;
                    }
                    else
                    {
                        awaiter = client.SendAsync(HttpMethod.Get, this.url, this.token, null, this.authHeader, null).GetAwaiter();
                        if (awaiter.IsCompleted)
                        {
                            goto TR_0004;
                        }
                        else
                        {
                            this.<>1__state = num = 0;
                            this.<>u__1 = awaiter;
                            this.<>t__builder.AwaitUnsafeOnCompleted<TaskAwaiter<WebResponse>, WebClient.<GetAsync>d__4>(ref awaiter, ref this);
                        }
                    }
                    return;
                TR_0004:
                    response = awaiter.GetResult();
                    this.<>1__state = -2;
                    this.<>t__builder.SetResult(response);
                }
                catch (Exception exception)
                {
                    this.<>1__state = -2;
                    this.<>t__builder.SetException(exception);
                }
            }

            [DebuggerHidden]
            private void SetStateMachine(IAsyncStateMachine stateMachine)
            {
                this.<>t__builder.SetStateMachine(stateMachine);
            }
        }

        [CompilerGenerated]
        private struct <PostAsync>d__3 : IAsyncStateMachine
        {
            public int <>1__state;
            public AsyncTaskMethodBuilder<WebResponse> <>t__builder;
            public WebClient <>4__this;
            public string url;
            public CancellationToken token;
            public object postData;
            public AuthenticationHeaderValue authHeader;
            private TaskAwaiter<WebResponse> <>u__1;

            private void MoveNext()
            {
                int num = this.<>1__state;
                WebClient client = this.<>4__this;
                try
                {
                    WebResponse response;
                    TaskAwaiter<WebResponse> awaiter;
                    if (num == 0)
                    {
                        awaiter = this.<>u__1;
                        this.<>u__1 = new TaskAwaiter<WebResponse>();
                        this.<>1__state = num = -1;
                        goto TR_0004;
                    }
                    else
                    {
                        awaiter = client.SendAsync(HttpMethod.Post, this.url, this.token, this.postData, this.authHeader, null).GetAwaiter();
                        if (awaiter.IsCompleted)
                        {
                            goto TR_0004;
                        }
                        else
                        {
                            this.<>1__state = num = 0;
                            this.<>u__1 = awaiter;
                            this.<>t__builder.AwaitUnsafeOnCompleted<TaskAwaiter<WebResponse>, WebClient.<PostAsync>d__3>(ref awaiter, ref this);
                        }
                    }
                    return;
                TR_0004:
                    response = awaiter.GetResult();
                    this.<>1__state = -2;
                    this.<>t__builder.SetResult(response);
                }
                catch (Exception exception)
                {
                    this.<>1__state = -2;
                    this.<>t__builder.SetException(exception);
                }
            }

            [DebuggerHidden]
            private void SetStateMachine(IAsyncStateMachine stateMachine)
            {
                this.<>t__builder.SetStateMachine(stateMachine);
            }
        }

        [CompilerGenerated]
        private struct <SendAsync>d__7 : IAsyncStateMachine
        {
            public int <>1__state;
            public AsyncTaskMethodBuilder<WebResponse> <>t__builder;
            public HttpMethod methodType;
            public string url;
            public AuthenticationHeaderValue authHeader;
            public object postData;
            public WebClient <>4__this;
            public CancellationToken token;
            public IProgress<double> progress;
            private HttpResponseMessage <resp>5__2;
            private ConfiguredTaskAwaitable<HttpResponseMessage>.ConfiguredTaskAwaiter <>u__1;
            private MemoryStream <memoryStream>5__3;
            private Stream <stream>5__4;
            private TaskAwaiter<Stream> <>u__2;
            private byte[] <buffer>5__5;
            private int <bytesRead>5__6;
            private long? <contentLength>5__7;
            private int <totalRead>5__8;
            private TaskAwaiter <>u__3;
            private TaskAwaiter<int> <>u__4;

            private void MoveNext()
            {
                int num = this.<>1__state;
                WebClient client = this.<>4__this;
                try
                {
                    HttpResponseMessage message2;
                    ConfiguredTaskAwaitable<HttpResponseMessage>.ConfiguredTaskAwaiter awaiter;
                    if (num == 0)
                    {
                        awaiter = this.<>u__1;
                        this.<>u__1 = new ConfiguredTaskAwaitable<HttpResponseMessage>.ConfiguredTaskAwaiter();
                        this.<>1__state = num = -1;
                    }
                    else
                    {
                        if ((num - 1) <= 2)
                        {
                            goto TR_002F;
                        }
                        else
                        {
                            Plugin.Log.Debug("Sending web request");
                            Plugin.Log.Debug(this.methodType.ToString() + ": " + this.url);
                            HttpRequestMessage request = new HttpRequestMessage(this.methodType, this.url) {
                                Headers = { Authorization = this.authHeader }
                            };
                            if ((this.methodType == HttpMethod.Post) && (this.postData != null))
                            {
                                request.Content = new StringContent(JsonConvert.SerializeObject(this.postData), Encoding.UTF8, "application/json");
                            }
                            awaiter = client._client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, this.token).ConfigureAwait(false).GetAwaiter();
                            if (awaiter.IsCompleted)
                            {
                                goto TR_0031;
                            }
                            else
                            {
                                this.<>1__state = num = 0;
                                this.<>u__1 = awaiter;
                                this.<>t__builder.AwaitUnsafeOnCompleted<ConfiguredTaskAwaitable<HttpResponseMessage>.ConfiguredTaskAwaiter, WebClient.<SendAsync>d__7>(ref awaiter, ref this);
                            }
                        }
                        return;
                    }
                    goto TR_0031;
                TR_002F:
                    try
                    {
                        Stream stream;
                        TaskAwaiter<Stream> awaiter2;
                        if (num == 1)
                        {
                            awaiter2 = this.<>u__2;
                            this.<>u__2 = new TaskAwaiter<Stream>();
                            this.<>1__state = num = -1;
                            goto TR_0029;
                        }
                        else if ((num - 2) <= 1)
                        {
                            goto TR_0028;
                        }
                        else
                        {
                            awaiter2 = this.<resp>5__2.Content.ReadAsStreamAsync().GetAwaiter();
                            if (awaiter2.IsCompleted)
                            {
                                goto TR_0029;
                            }
                            else
                            {
                                this.<>1__state = num = 1;
                                this.<>u__2 = awaiter2;
                                this.<>t__builder.AwaitUnsafeOnCompleted<TaskAwaiter<Stream>, WebClient.<SendAsync>d__7>(ref awaiter2, ref this);
                            }
                        }
                        return;
                    TR_0028:
                        try
                        {
                            WebResponse response;
                            TaskAwaiter awaiter3;
                            int num2;
                            TaskAwaiter<int> awaiter4;
                            if (num == 2)
                            {
                                awaiter3 = this.<>u__3;
                                this.<>u__3 = new TaskAwaiter();
                                this.<>1__state = num = -1;
                                goto TR_0013;
                            }
                            else if (num == 3)
                            {
                                awaiter4 = this.<>u__4;
                                this.<>u__4 = new TaskAwaiter<int>();
                                this.<>1__state = num = -1;
                                goto TR_001B;
                            }
                            else
                            {
                                this.<buffer>5__5 = new byte[0x2000];
                                this.<bytesRead>5__6 = 0;
                                this.<contentLength>5__7 = this.<resp>5__2.Content.Headers.ContentLength;
                                this.<totalRead>5__8 = 0;
                                if (this.progress == null)
                                {
                                    IProgress<double> progress = this.progress;
                                }
                                else
                                {
                                    this.progress.Report(0.0);
                                }
                            }
                            goto TR_001F;
                        TR_0013:
                            awaiter3.GetResult();
                            this.<totalRead>5__8 += this.<bytesRead>5__6;
                            goto TR_001F;
                        TR_001B:
                            num2 = awaiter4.GetResult();
                            this.<bytesRead>5__6 = num2;
                            if (this.<bytesRead>5__6 > 0)
                            {
                                if (this.token.IsCancellationRequested)
                                {
                                    throw new TaskCanceledException();
                                }
                                if (this.<contentLength>5__7 != null)
                                {
                                    if (this.progress == null)
                                    {
                                        IProgress<double> progress = this.progress;
                                    }
                                    else
                                    {
                                        this.progress.Report(((double) this.<totalRead>5__8) / ((double) this.<contentLength>5__7.Value));
                                    }
                                }
                                awaiter3 = this.<memoryStream>5__3.WriteAsync(this.<buffer>5__5, 0, this.<bytesRead>5__6).GetAwaiter();
                                if (awaiter3.IsCompleted)
                                {
                                    goto TR_0013;
                                }
                                else
                                {
                                    this.<>1__state = num = 2;
                                    this.<>u__3 = awaiter3;
                                    this.<>t__builder.AwaitUnsafeOnCompleted<TaskAwaiter, WebClient.<SendAsync>d__7>(ref awaiter3, ref this);
                                }
                                return;
                            }
                            else
                            {
                                if (this.progress == null)
                                {
                                    IProgress<double> progress = this.progress;
                                }
                                else
                                {
                                    this.progress.Report(1.0);
                                }
                                byte[] content = this.<memoryStream>5__3.ToArray();
                                response = new WebResponse(this.<resp>5__2, content);
                            }
                            this.<>1__state = -2;
                            this.<>t__builder.SetResult(response);
                            return;
                        TR_001F:
                            while (true)
                            {
                                awaiter4 = this.<stream>5__4.ReadAsync(this.<buffer>5__5, 0, this.<buffer>5__5.Length).GetAwaiter();
                                if (awaiter4.IsCompleted)
                                {
                                    break;
                                }
                                this.<>1__state = num = 3;
                                this.<>u__4 = awaiter4;
                                this.<>t__builder.AwaitUnsafeOnCompleted<TaskAwaiter<int>, WebClient.<SendAsync>d__7>(ref awaiter4, ref this);
                                return;
                            }
                            goto TR_001B;
                        }
                        finally
                        {
                            if ((num < 0) && (this.<stream>5__4 != null))
                            {
                                this.<stream>5__4.Dispose();
                            }
                        }
                    TR_0029:
                        stream = awaiter2.GetResult();
                        this.<stream>5__4 = stream;
                        goto TR_0028;
                    }
                    finally
                    {
                        if ((num < 0) && (this.<memoryStream>5__3 != null))
                        {
                            this.<memoryStream>5__3.Dispose();
                        }
                    }
                    return;
                TR_0031:
                    message2 = awaiter.GetResult();
                    this.<resp>5__2 = message2;
                    if (this.token.IsCancellationRequested)
                    {
                        throw new TaskCanceledException();
                    }
                    this.<memoryStream>5__3 = new MemoryStream();
                    goto TR_002F;
                }
                catch (Exception exception)
                {
                    this.<>1__state = -2;
                    this.<>t__builder.SetException(exception);
                }
            }

            [DebuggerHidden]
            private void SetStateMachine(IAsyncStateMachine stateMachine)
            {
                this.<>t__builder.SetStateMachine(stateMachine);
            }
        }
    }
}
