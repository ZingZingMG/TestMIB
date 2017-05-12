using System;


namespace GameUtill
{
    /// <summary>
    /// 디버깅을 도와주는 유틸 클래스
    /// </summary>
    public static class Debug
    {
        /// <summary>
        /// 현재까지 스택트레이스를 출력한다.
        /// </summary>
        public static void GetStackTrace()
        {
            System.Diagnostics.Debug.WriteLine(Environment.StackTrace);
        }
        /// <summary>
        /// 콘솔에 스트릴을 출력한다.
        /// </summary>
        /// <param name="format"></param>
        /// <param name="args"></param>
        public static void PrintConsole(string format, params object[] args)
        {
            string msg = string.Format(format, args);
            System.Console.Write(msg);
        }
        /// <summary>
        /// 현재 파일 이름
        /// </summary>
        public static string CurrentFile
        {
            get
            {
                return new System.Diagnostics.StackTrace(true).GetFrame(1).GetFileName();
            }
        }
        /// <summary>
        /// 현재 파일의 라인번호
        /// </summary>
        public static int CurrentLine
        {
            get
            {
                return new System.Diagnostics.StackTrace(true).GetFrame(1).GetFileLineNumber();
            }
        }
        public static void TODO(string format, params object[] args)
        {
            string file_name = new System.Diagnostics.StackTrace(true).GetFrame(1).GetFileName();
            int file_number = new System.Diagnostics.StackTrace(true).GetFrame(1).GetFileLineNumber();
            string msg = string.Format(format, args);
            string todo = string.Format("{0}({1}) : {2}", file_name, file_number, msg);
            System.Console.WriteLine(todo);
        }
    }
}