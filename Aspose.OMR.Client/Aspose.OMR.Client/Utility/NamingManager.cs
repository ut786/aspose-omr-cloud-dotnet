﻿/*
 * Copyright (c) 2018 Aspose Pty Ltd. All Rights Reserved.
 *
 * Licensed under the MIT (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *       https://github.com/aspose-omr-cloud/aspose-omr-cloud-dotnet/blob/master/LICENSE
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */
namespace Aspose.OMR.Client.Utility
{
    using System;
    using System.Collections.Generic;
    using ViewModels;

    /// <summary>
    /// Handles providing names for new elements
    /// </summary>
    public static class NamingManager
    {
        /// <summary>
        /// Prefix for autogenerated names for questions
        /// </summary>
        private const string QuestionNamePrefix = "Question";

        /// <summary>
        /// Prefix for autogenerated clip areas names
        /// </summary>
        private const string ClipAreaNamePrefix = "ClipArea";

        /// <summary>
        /// Prefix for autogenerated barcode names
        /// </summary>
        private const string BarcodeNamePrefix = "Barcode";

        /// <summary>
        /// Gets next unique name for the element
        /// </summary>
        /// <param name="pageQuestions">Existing page questions</param>
        /// <returns>A new unused name for an element</returns>
        public static string GetNextAvailableElementName(IEnumerable<BaseQuestionViewModel> pageQuestions)
        {
            int currentTopNumber = 0;
            foreach (BaseQuestionViewModel element in pageQuestions)
            {
                if (element.Name.StartsWith(QuestionNamePrefix))
                {
                    string numberPart = element.Name.Substring(QuestionNamePrefix.Length);
                    int thisNumber;
                    if (int.TryParse(numberPart, out thisNumber))
                    {
                        currentTopNumber = Math.Max(currentTopNumber, thisNumber);
                    }
                }
            }

            return QuestionNamePrefix + (currentTopNumber + 1);
        }

        /// <summary>
        /// Gets next unique name for the barcode element
        /// </summary>
        /// <param name="pageQuestions">Existing page questions</param>
        /// <returns>A new unused name for the barcode</returns>
        public static string GetNextAvailableBarcodeName(IEnumerable<BaseQuestionViewModel> pageQuestions)
        {
            int currentTopNumber = 0;
            foreach (BaseQuestionViewModel element in pageQuestions)
            {
                if (element.Name.StartsWith(BarcodeNamePrefix))
                {
                    string numberPart = element.Name.Substring(BarcodeNamePrefix.Length);
                    int thisNumber;
                    if (int.TryParse(numberPart, out thisNumber))
                    {
                        currentTopNumber = Math.Max(currentTopNumber, thisNumber);
                    }
                }
            }

            return BarcodeNamePrefix + (currentTopNumber + 1);
        }

        /// <summary>
        /// Gets next unique name for the clip area element
        /// </summary>
        /// <param name="pageQuestions">Existing page questions</param>
        /// <returns>A new unused name for the clip area</returns>
        public static string GetNextAvailableAreaName(IEnumerable<BaseQuestionViewModel> pageQuestions)
        {
            int currentTopNumber = 0;
            foreach (BaseQuestionViewModel element in pageQuestions)
            {
                if (element.Name.StartsWith(ClipAreaNamePrefix))
                {
                    string numberPart = element.Name.Substring(ClipAreaNamePrefix.Length);
                    int thisNumber;
                    if (int.TryParse(numberPart, out thisNumber))
                    {
                        currentTopNumber = Math.Max(currentTopNumber, thisNumber);
                    }
                }
            }

            return ClipAreaNamePrefix + (currentTopNumber + 1);
        }
    }
}
