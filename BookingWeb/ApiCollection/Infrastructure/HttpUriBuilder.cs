using System;
using System.Web;

namespace BookingWeb.ApiCollection.Infrastructure
{
    public class HttpUriBuilder
    {
        private readonly string _fullUrl;
        private UriBuilder _builder;
        public HttpUriBuilder(string url)
        {
            _fullUrl = url;
            _builder = new UriBuilder(url);
        }
        public Uri Uri => _builder.Uri;
        public HttpUriBuilder Scheme(string scheme)
        {
            _builder.Scheme = scheme;
            return this;
        }
        public HttpUriBuilder Host(string host)
        {
            _builder.Host = host;
            return this;
        }
        public HttpUriBuilder Port(int port)
        {
            _builder.Port = port;
            return this;
        }
        public HttpUriBuilder AddToPath(string path)
        {
            IncludePath(path);
            return this;
        }
        public HttpUriBuilder SetPath(string path)
        {
            _builder.Path = path;
            return this;
        }
        public void IncludePath(string path)
        {
            if (string.IsNullOrEmpty(_builder.Path)
            || _builder.Path == "/")
            {
                _builder.Path = path;
            }
            else
            {
                var newPath = $"{_builder.Path}/{path}";
                _builder.Path = newPath.Replace("//", "/");
            }
        }
        public HttpUriBuilder Fragment(string fragment)
        {
            _builder.Fragment = fragment;
            return this;
        }
        public HttpUriBuilder SetSubdomain(string subdomain)
        {
            _builder.Host = string.Concat(subdomain, ".", new Uri(_fullUrl).Host);
            return this;
        }
        public bool HasSubdomain()
        {
            return _builder.Uri.HostNameType == UriHostNameType.Dns
            && _builder.Uri.Host.Split('.').Length > 2;
        }
        public HttpUriBuilder AddQueryString(string name, string value)
        {
            var qsNv = HttpUtility.ParseQueryString(_builder.Query);
            qsNv[name] = string.IsNullOrEmpty(qsNv[name])
            ? value
            : string.Concat(qsNv[name], ",", value);
            _builder.Query = qsNv.ToString();
            return this;
        }
        public HttpUriBuilder QueryString(string queryString)
        {
            if (!string.IsNullOrEmpty(queryString))
            {
                _builder.Query = queryString;
            }
            return this;
        }
        public HttpUriBuilder UserName(string username)
        {
            _builder.UserName = username;
            return this;
        }
        public HttpUriBuilder Password(string password)
        {
            _builder.Password = password;
            return this;
        }
        public string GetLeftPart()
        {
            return _builder.Uri.GetLeftPart(UriPartial.Path);
        }

    }
}
