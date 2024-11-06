using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesAndEvents
{
    public static class MessagesConst
    {
        public static readonly string NameForCancel = "Cancel_file";

        #region Strings
        public static readonly string PathFolder = "Введите путь до папки: ";
        public static readonly string PressAnyToContinue = "Нажмите любую клавишу для продолжения...";
        public static readonly string ExitMessage = "Выход из программы.";
        public static readonly string DelegateEvent = "Делегаты и события";
        public static readonly string MenuCaption = "Меню настроек";
        public static readonly string GroupIEnumerable = "Расширение IEnumerable";
        public static readonly string CallGetMin = "Вызвать GetMin";
        public static readonly string CallGetMax = "Вызвать GetMax";
        public static readonly string CallGetAverage = "Вызвать GetAverage";
        public static readonly string GroupFile = "Работа с файлами";
        public static readonly string ShowFilesFromFolder = "Отобразить файлы из папки по пути";
        public static readonly string Explorer = "Проводник";
        public static readonly string Exit = "Выход";
        public static readonly string TMost = "Наимешьшее:";
        public static readonly string THighest = "Наибольшее:";
        public static readonly string TMeaning = "Среднее значение:";
        public static readonly string Down = "Назад";
        public static readonly string FileNotFound = "Файл найден:";
        public static readonly string GreaterZeroCollection = "Элементов в коллекции (больше нуля):";
        public static readonly string StartValueCollection = "Начальное значение диапазона значений коллекции:";
        public static readonly string EndValueCollection = "Конечное значение диапазона значений коллекции (больше начального):";
        public static readonly string GeneratedData = "Сгенерированные данные:";
        public static readonly string SearchFileCancel = "Поиск файлов отменен.";
        public static readonly string SearchFolderCancel = "Поиск папок отменен.";
        public static readonly string HelpMoveMessage = "Используйте стрелки влево/вправо для переключения страниц.";
        #endregion
        #region Errors
        public static readonly string ErrorNotFoundHandler =  "Selected event handler must be provided if the menu item is enabled.";
        public static readonly string ErrorOpenFile = "Ошибка при открытии файла:";
        public static readonly string FilePathNotFound = "Указанный путь не существует.";
        public static readonly string RangeEx = "Конец диапазона должен быть больше начала диапазона.";
        public static readonly string PathNotValid = "Путь не найден";
        #endregion
    }
}
