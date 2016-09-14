using Dapper;
using System;
using System.Configuration;
using System.Data.SqlClient;

namespace Poc_HangFire.Repositories
{
    public interface IPocRepository
    {
        bool Salvar(DateTime date, string value);
    }
}