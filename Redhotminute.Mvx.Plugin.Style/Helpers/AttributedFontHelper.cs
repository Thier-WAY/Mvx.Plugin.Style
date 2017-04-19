﻿using System;
using System.Collections.Generic;

namespace Redhotminute.Mvx.Plugin.Style {
	public class AttributedFontHelper {
		public static List<FontIndexPair> GetFontTextBlocks(string text,string fontName,IAssetPlugin assetPlugin,out string cleanText) {
			cleanText = string.Empty;

			if (string.IsNullOrWhiteSpace(fontName)) {
				return null;
			}

			//this is a sample <h1>text and</h1> it ends here <h2>more stuff</h2>
			//0				   1  2        3   4

			//find the first text
			int findIndex = 0;

			List<FontTextPair> fontTextBlocks = new List<FontTextPair>();

			int beginTagStartIndex = -1;
			int beginTagEndIndex = -1;

			int endTagStartIndex = -1;
			int endTagEndIndex = -1;

			//Start searching for tags
			bool foundTag = true;
			while (foundTag) {
				beginTagStartIndex = text.IndexOf('<', findIndex);
				string tag = string.Empty;
				string endTag = string.Empty;

				if (beginTagStartIndex != -1) {
					//find the end of the tag
					beginTagEndIndex = text.IndexOf('>', beginTagStartIndex);

					if (beginTagEndIndex != -1) {

						//there's a tag, get the description
						tag = text.Substring(beginTagStartIndex + 1, beginTagEndIndex - beginTagStartIndex - 1);

						//find the end Index
						endTag = $"</{tag}>";
						endTagStartIndex = text.IndexOf(endTag, beginTagEndIndex);

						endTagEndIndex = endTagStartIndex + endTag.Length;

						fontTextBlocks.Add(new FontTextPair() { Text = text.Substring(findIndex, beginTagStartIndex - findIndex), FontTag = string.Empty });

						//from 2 to 3
						fontTextBlocks.Add(new FontTextPair() { Text = text.Substring(beginTagEndIndex + 1, endTagStartIndex - beginTagEndIndex - 1), FontTag = tag });
						findIndex = endTagEndIndex;
					}
				}
				else {
					foundTag = false;
				}
			}
			//check if the end tag is the last character, if not add a final block till the end
			if (endTagEndIndex != text.Length) {
				fontTextBlocks.Add(new FontTextPair() { Text = text.Substring(endTagEndIndex + 1, text.Length - endTagEndIndex - 1), FontTag = string.Empty });
			}

			//create a clean text and convert the block fontTag pairs to indexTagPairs do that we know which text we need to decorate without tags present
			List<FontIndexPair> blockIndexes = new List<FontIndexPair>();

			int previousIndex = 0;
			foreach (FontTextPair block in fontTextBlocks) {
				cleanText = $"{cleanText}{block.Text}";
				blockIndexes.Add(new FontIndexPair() { FontTag = block.FontTag, StartIndex = previousIndex, EndIndex = cleanText.Length });
				previousIndex = cleanText.Length;
			}

			return blockIndexes;
		}
	}


	public class FontTextPair {
		public string FontTag {
			get;
			set;
		}

		public string Text {
			get;
			set;
		}
	}

	public class FontIndexPair {
		public string FontTag {
			get;
			set;
		}

		public int StartIndex {
			get;
			set;
		}

		public int EndIndex {
			get;
			set;
		}
	}
}