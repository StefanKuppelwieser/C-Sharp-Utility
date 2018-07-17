using System;
using System.Windows.Input;

namespace Utility
{
    /// <summary>
    /// The class changes the type from the cursor and restores the previous cursors after exiting
    /// </summary>
    public class ChangeCurser : IDisposable
    {
        /// <summary>
        /// It contains the status of the ChangeCurser before the status is changed
        /// </summary>
        private Cursor _previousCursor;

        /// <summary>
        /// Changes the type of the cursor
        /// </summary>
        /// <param name="type">It contains the type in which the cursor should be changed</param>
        /// <example>This sample shows how to call Class with the Wait Curser
        /// <code>
        /// 
        /// using (new Utility.ChangeCurser(Cursors.Wait))
        /// {
        ///     //Your long code
        /// }
        ///</code>
        public ChangeCurser(Cursor type)
        {
            _previousCursor = Mouse.OverrideCursor;

            Mouse.OverrideCursor = type;
        }

        /// <summary>
        /// Restores the status of the ChangeCurser
        /// </summary>
        public void Dispose()
        {
            Mouse.OverrideCursor = _previousCursor;
        }
    }
}
