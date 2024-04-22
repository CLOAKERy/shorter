using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.BusinessModel
{
    public class ShortLinkGenerator
    {
        public static string GenerateShortLink()
        {
            // Генерируем глобально уникальный идентификатор (GUID)
            string guid = Guid.NewGuid().ToString();

            // Убираем дефисы и преобразуем в нижний регистр
            string shortLink = guid.Replace("-", "").ToLower();

            // Возвращаем первые 8 символов в качестве короткой ссылки
            return shortLink.Substring(0, 8);
        }
    }
}
