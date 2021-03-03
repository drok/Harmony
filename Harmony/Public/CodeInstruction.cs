using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;

namespace HarmonyLib
{
	/// <summary>An abstract wrapper around OpCode and their operands. Used by transpilers</summary>
	///
	public class CodeInstruction
	{
		/// <summary>The opcode</summary>
		/// 
		public OpCode opcode;

		/// <summary>The operand</summary>
		///
		public object operand;

		/// <summary>All labels defined on this instruction</summary>
		/// 
		public List<Label> labels = new List<Label>();

		/// <summary>All exception block boundaries defined on this instruction</summary>
		/// 
		public List<ExceptionBlock> blocks = new List<ExceptionBlock>();

		/// <summary>Creates a new CodeInstruction with a given opcode and optional operand</summary>
		/// <param name="opcode">The opcode</param>
		/// <param name="operand">The operand</param>
		///
		public CodeInstruction(OpCode opcode, object operand = null)
		{
			this.opcode = opcode;
			this.operand = operand;
		}

		/// <summary>Create a full copy (including labels and exception blocks) of a CodeInstruction</summary>
		/// <param name="instruction">The <see cref="CodeInstruction"/> to copy</param>
		///
		public CodeInstruction(CodeInstruction instruction)
		{
			opcode = instruction.opcode;
			operand = instruction.operand;
			labels = instruction.labels.ToList();
			blocks = instruction.blocks.ToList();
		}

		/// <summary>Clones a CodeInstruction and resets its labels and exception blocks</summary>
		/// <returns>A lightweight copy of this code instruction</returns>
		///
		public CodeInstruction Clone()
		{
			return new CodeInstruction(this)
			{
				labels = new List<Label>(),
				blocks = new List<ExceptionBlock>()
			};
		}

		/// <summary>Clones a CodeInstruction, resets labels and exception blocks and sets its opcode</summary>
		/// <param name="opcode">The opcode</param>
		/// <returns>A copy of this CodeInstruction with a new opcode</returns>
		///
		public CodeInstruction Clone(OpCode opcode)
		{
			var instruction = Clone();
			instruction.opcode = opcode;
			return instruction;
		}

		/// <summary>Clones a CodeInstruction, resets labels and exception blocks and sets its operand</summary>
		/// <param name="operand">The operand</param>
		/// <returns>A copy of this CodeInstruction with a new operand</returns>
		///
		public CodeInstruction Clone(object operand)
		{
			var instruction = Clone();
			instruction.operand = operand;
			return instruction;
		}

		/// <summary>Returns a string representation of the code instruction</summary>
		/// <returns>A string representation of the code instruction</returns>
		///
		public override string ToString()
		{
			var list = new List<string>();
			if (labels != null)
			{
				foreach (var label in labels)
					list.Add($"Label{label.GetHashCode()}");
			} else
			{
				/* because a null label list doesn't mean the same as an empty list */
				list.Add("*null label list*");
			}
			if (blocks != null)
			{
				foreach (var block in blocks)
					list.Add($"EX_{block.blockType.ToString().Replace("Block", "")}");
			}
			else
			{
				/* because a null block list doesn't mean the same as an empty list */
				list.Add("*null blocks list*");
			}

			var extras = list.Count > 0 ? $" [{string.Join(", ", list.ToArray())}]" : string.Empty;
			var operandStr = Emitter.FormatArgument(operand);
			if (operandStr.Length > 0) operandStr = " " + operandStr;
			return opcode + operandStr + extras;
		}
	}
}