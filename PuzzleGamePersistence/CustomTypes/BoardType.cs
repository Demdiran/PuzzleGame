using System;
using System.Data;
using System.Data.Common;
using NHibernate;
using NHibernate.Engine;
using NHibernate.SqlTypes;
using NHibernate.UserTypes;
using PuzzleGameDomain;
using Newtonsoft.Json;

namespace PuzzleGamePersistence.CustomTypes
{
    public class BoardType: IUserType
    {
        public SqlType[] SqlTypes => new []{new SqlType(DbType.String)};

        public Type ReturnedType => typeof(Square[][]);

        public bool Equals(object x, object y)
        {
            if (x == null) return false;
            return x.Equals(y);
        }

        public int GetHashCode(object x) => x.GetHashCode();

        public object NullSafeGet(DbDataReader rs, string[] names, ISessionImplementor session, object owner)
        {
            var jsonBoard = (string) NHibernateUtil.String.NullSafeGet(rs, names[0], session);
            if (jsonBoard == null) return null;
            var resultBoard = JsonConvert.DeserializeObject<Square[][]>(jsonBoard);
            return resultBoard;
        }

        public void NullSafeSet(DbCommand cmd, object value, int index, ISessionImplementor session)
        {
            if (value == null)
            {
                NHibernateUtil.String.NullSafeSet(cmd, value, index, session);
            }
            else
            {
                var jsonBoard = JsonConvert.SerializeObject(value);
                NHibernateUtil.String.NullSafeSet(cmd, jsonBoard, index, session);
            }
        }

        public object DeepCopy(object value)
        {
            return value;
        }

        public bool IsMutable => false;

        public object Replace(object original, object target, object owner)
        {
            return original;
        }

        public object Assemble(object cached, object owner)
        {
            return cached;
        }

        public object Disassemble(object value)
        {
            return value;
        }
    }
}