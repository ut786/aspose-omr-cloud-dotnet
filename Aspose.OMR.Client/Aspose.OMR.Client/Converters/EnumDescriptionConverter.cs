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
namespace Aspose.OMR.Client.Converters
{
    using System;
    using System.Globalization;
    using System.Windows;
    using System.Windows.Data;
    using System.Windows.Markup;
    using Utility;

    /// <summary>
    /// Converts enum description to user-friendly string according to description attribute
    /// </summary>
    public class EnumDescriptionConverter : MarkupExtension, IValueConverter
    {
        private static EnumDescriptionConverter converter;

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (string.IsNullOrEmpty(value.ToString()))
            {
                return value;
            }

            // parameter determines which enum exactly to examine, provided in xaml
            if (parameter != null)
            {
                if (string.Equals("markup", parameter))
                {
                    return StringToEnum<PredefinedMarkups>(value.ToString()).GetEnumDescription();
                }
                else if (string.Equals("preset", parameter))
                {
                    return StringToEnum<PreprocessingPreset>(value.ToString()).GetEnumDescription();
                }
            }

            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (string.IsNullOrEmpty(value.ToString()))
            {
                return DependencyProperty.UnsetValue;
            }

            return StringToEnum<PreprocessingPreset>(value.ToString());
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return converter ?? (converter = new EnumDescriptionConverter());
        }

        public static T StringToEnum<T>(string name)
        {
            return (T)Enum.Parse(typeof(T), name);
        }
    }
}
