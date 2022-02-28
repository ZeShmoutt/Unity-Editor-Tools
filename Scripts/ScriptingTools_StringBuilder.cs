using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace ZeShmouttsAssets.ScriptingTools
{
	public static class ScriptingTools_StringBuilder
	{
		public static void AppendIndented(this StringBuilder builder, int indent, string content)
		{
			builder.IndentStringBuilder(indent);
			builder.Append(content);
		}

		public static void AppendIndented(this StringBuilder builder, int indent, int content)
		{
			builder.AppendIndented(indent, content.ToString());
		}

		public static void AppendIndentedLine(this StringBuilder builder, int indent, string content)
		{
			builder.IndentStringBuilder(indent);
			builder.AppendLine(content);
		}

		public static void AppendIndentedLine(this StringBuilder builder, int indent, int content)
		{
			builder.AppendIndentedLine(indent, content.ToString());
		}

		public static void IndentStringBuilder(this StringBuilder builder, int indent)
		{
			builder.Append(new string('\t', indent));
		}
	}
}