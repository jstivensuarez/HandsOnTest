using System;
using System.Collections.Generic;
using System.Text;

namespace HandsOnTest.Data
{
    public interface IHttpRequestTemplate
    {
        T Get<T>(string path) where T : class, new();
    }
}
