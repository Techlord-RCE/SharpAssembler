﻿#region Copyright and License
/*
 * SharpAssembler
 * Library for .NET that assembles a predetermined list of
 * instructions into machine code.
 * 
 * Copyright (C) 2011-2012 Daniël Pelsmaeker
 * 
 * This file is part of SharpAssembler.
 * 
 * SharpAssembler is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 * 
 * SharpAssembler is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 * 
 * You should have received a copy of the GNU General Public License
 * along with SharpAssembler.  If not, see <http://www.gnu.org/licenses/>.
 */
#endregion
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using SharpAssembler;
using SharpAssembler.Architectures.X86.Operands;

namespace SharpAssembler.Architectures.X86.Instructions
{
	/// <summary>
	/// The RCR (Rotate Through Carry Right) instruction.
	/// </summary>
	public class Rcr : X86Instruction
	{
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="Rcr"/> class.
		/// </summary>
		/// <param name="value">The value to change.</param>
		public Rcr(EffectiveAddress value)
			: this((Operand)value, null)
		{
			#region Contract
			Contract.Requires<ArgumentNullException>(value != null);
			#endregion
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Rcr"/> class.
		/// </summary>
		/// <param name="value">The value to change.</param>
		public Rcr(RegisterOperand value)
			: this((Operand)value, null)
		{
			#region Contract
			Contract.Requires<ArgumentNullException>(value != null);
			#endregion
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Rcr"/> class.
		/// </summary>
		/// <param name="value">The value to change.</param>
		/// <param name="positions">The register containing the number of positions to adjust.</param>
		public Rcr(EffectiveAddress value, RegisterOperand positions)
			: this((Operand)value, (Operand)positions)
		{
			#region Contract
			Contract.Requires<ArgumentNullException>(value != null);
			Contract.Requires<ArgumentNullException>(positions != null);
			#endregion
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Rcr"/> class.
		/// </summary>
		/// <param name="value">The value to change.</param>
		/// <param name="positions">The register containing the number of positions to adjust.</param>
		public Rcr(RegisterOperand value, RegisterOperand positions)
			: this((Operand)value, (Operand)positions)
		{
			#region Contract
			Contract.Requires<ArgumentNullException>(value != null);
			Contract.Requires<ArgumentNullException>(positions != null);
			#endregion
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Rcr"/> class.
		/// </summary>
		/// <param name="value">The value to change.</param>
		/// <param name="positions">The number of positions to adjust.</param>
		public Rcr(EffectiveAddress value, Immediate positions)
			: this((Operand)value, (Operand)positions)
		{
			#region Contract
			Contract.Requires<ArgumentNullException>(value != null);
			Contract.Requires<ArgumentNullException>(positions != null);
			#endregion
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Rcr"/> class.
		/// </summary>
		/// <param name="value">The value to change.</param>
		/// <param name="positions">The number of positions to adjust.</param>
		public Rcr(RegisterOperand value, Immediate positions)
			: this((Operand)value, (Operand)positions)
		{
			#region Contract
			Contract.Requires<ArgumentNullException>(value != null);
			Contract.Requires<ArgumentNullException>(positions != null);
			#endregion
		}


		/// <summary>
		/// Initializes a new instance of the <see cref="Rcr"/> class.
		/// </summary>
		/// <param name="value">The value to change.</param>
		/// <param name="positions">The number of positions to adjust;
		/// or <see langword="null"/> to adjust one position.</param>
		private Rcr(Operand value, Operand positions)
		{
			#region Contract
			Contract.Requires<ArgumentNullException>(value != null);
			Contract.Requires<InvalidCastException>(
					value is EffectiveAddress ||
					value is RegisterOperand);
			Contract.Requires<InvalidCastException>(positions != null || (
					positions is Immediate ||
					positions is EffectiveAddress ||
					positions is RegisterOperand));
			#endregion

			this.value = value;
			this.positions = positions;
		}
		#endregion

		#region Properties
		/// <summary>
		/// Gets the mnemonic of the instruction.
		/// </summary>
		/// <value>The mnemonic of the instruction.</value>
		public override string Mnemonic
		{
			get { return "rcr"; }
		}

		private Operand positions;
		/// <summary>
		/// Gets the number of positions to rotate.
		/// </summary>
		/// <value>An <see cref="Operand"/>; or <see langword="null"/>.</value>
		public Operand Positions
		{
			get
			{
				#region Contract
				Contract.Ensures(Contract.Result<Operand>() == null || (
					Contract.Result<Operand>() is Immediate ||
					Contract.Result<Operand>() is EffectiveAddress ||
					Contract.Result<Operand>() is RegisterOperand));
				#endregion
				return positions;
			}
#if OPERAND_SET
			set
			{
				#region Contract
				Contract.Requires<InvalidCastException>(value == null || (
					value is Immediate ||
					value is EffectiveAddress ||
					value is RegisterOperand));
				#endregion
				positions = value;
			}
#endif
		}

		private Operand value;
		/// <summary>
		/// Gets the value being modified.
		/// </summary>
		/// <value>An <see cref="Operand"/>.</value>
		public Operand Value
		{
			get
			{
				#region Contract
				Contract.Ensures(Contract.Result<Operand>() != null);
				Contract.Ensures(
					Contract.Result<Operand>() is EffectiveAddress ||
					Contract.Result<Operand>() is RegisterOperand);
				#endregion
				return value;
			}
#if OPERAND_SET
			set
			{
				#region Contract
				Contract.Requires<ArgumentNullException>(value != null);
				Contract.Requires<InvalidCastException>(
					value is EffectiveAddress ||
					value is RegisterOperand);
				#endregion
				this.value = value;
			}
#endif
		}
		#endregion

		#region Methods
		/// <summary>
		/// Enumerates an ordered list of operands used by this instruction.
		/// </summary>
		/// <returns>An <see cref="IEnumerable{T}"/> of <see cref="Operand"/> objects.</returns>
		public override IEnumerable<Operand> GetOperands()
		{
			// The order is important here!
			yield return this.value;
			yield return this.positions;
		}
		#endregion

		#region Instruction Variants
		/// <summary>
		/// An array of <see cref="X86OpcodeVariant"/> objects
		/// describing the possible variants of this instruction.
		/// </summary>
		private static X86OpcodeVariant[] variants = new[]{
			// RCR reg/mem8, 1
			new X86OpcodeVariant(
				new byte[] { 0xD0 }, 3,
				new OperandDescriptor(OperandType.RegisterOrMemoryOperand, DataSize.Bit8),
				new OperandDescriptor(OperandType.None, DataSize.None)),
			// RCR reg/mem8, CL
			new X86OpcodeVariant(
				new byte[] { 0xD2 }, 3,
				new OperandDescriptor(OperandType.RegisterOrMemoryOperand, DataSize.Bit8),
				new OperandDescriptor(Register.CL)),
			// RCR reg/mem8, imm8
			new X86OpcodeVariant(
				new byte[] { 0xC0 }, 3,
				new OperandDescriptor(OperandType.RegisterOrMemoryOperand, DataSize.Bit8),
				new OperandDescriptor(OperandType.Immediate, DataSize.Bit8)),



			// RCR reg/mem16, 1
			new X86OpcodeVariant(
				new byte[] { 0xD1 }, 3,
				new OperandDescriptor(OperandType.RegisterOrMemoryOperand, DataSize.Bit8),
				new OperandDescriptor(OperandType.None, DataSize.None)),
			// RCR reg/mem16, CL
			new X86OpcodeVariant(
				new byte[] { 0xD3 }, 3,
				new OperandDescriptor(OperandType.RegisterOrMemoryOperand, DataSize.Bit8),
				new OperandDescriptor(Register.CL)),
			// RCR reg/mem16, imm8
			new X86OpcodeVariant(
				new byte[] { 0xC1 }, 3,
				new OperandDescriptor(OperandType.RegisterOrMemoryOperand, DataSize.Bit8),
				new OperandDescriptor(OperandType.Immediate, DataSize.Bit8)),



			// RCR reg/mem32, 1
			new X86OpcodeVariant(
				new byte[] { 0xD1 }, 3,
				new OperandDescriptor(OperandType.RegisterOrMemoryOperand, DataSize.Bit8),
				new OperandDescriptor(OperandType.None, DataSize.None)),
			// RCR reg/mem32, CL
			new X86OpcodeVariant(
				new byte[] { 0xD3 }, 3,
				new OperandDescriptor(OperandType.RegisterOrMemoryOperand, DataSize.Bit8),
				new OperandDescriptor(Register.CL)),
			// RCR reg/mem32, imm8
			new X86OpcodeVariant(
				new byte[] { 0xC1 }, 3,
				new OperandDescriptor(OperandType.RegisterOrMemoryOperand, DataSize.Bit8),
				new OperandDescriptor(OperandType.Immediate, DataSize.Bit8)),



			// RCR reg/mem64, 1
			new X86OpcodeVariant(
				new byte[] { 0xD1 }, 3,
				new OperandDescriptor(OperandType.RegisterOrMemoryOperand, DataSize.Bit8),
				new OperandDescriptor(OperandType.None, DataSize.None)),
			// RCR reg/mem64, CL
			new X86OpcodeVariant(
				new byte[] { 0xD3 }, 3,
				new OperandDescriptor(OperandType.RegisterOrMemoryOperand, DataSize.Bit8),
				new OperandDescriptor(Register.CL)),
			// RCR reg/mem64, imm8
			new X86OpcodeVariant(
				new byte[] { 0xC1 }, 3,
				new OperandDescriptor(OperandType.RegisterOrMemoryOperand, DataSize.Bit8),
				new OperandDescriptor(OperandType.Immediate, DataSize.Bit8)),
		};

		/// <summary>
		/// Returns an array containing the <see cref="X86OpcodeVariant"/>
		/// objects representing all the possible variants of this instruction.
		/// </summary>
		/// <returns>An array of <see cref="X86OpcodeVariant"/>
		/// objects.</returns>
		internal override X86OpcodeVariant[] GetVariantList()
		{ return variants; }
		#endregion
	}
}