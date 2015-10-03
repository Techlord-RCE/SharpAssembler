﻿//////////////////////////////////////////////////////
//                     WARNING                      //
//     The contents of this file is generated.      //
//    DO NOT MODIFY, your changes will be lost!     //
//////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using SharpAssembler.Architectures.X86.Opcodes;
using SharpAssembler.Architectures.X86.Operands;

namespace SharpAssembler.Architectures.X86.Opcodes
{
    /// <summary>
    /// The CMOVS (Move if sign) instruction opcode.
    /// </summary>
    public class CMovSOpcode : X86Opcode
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="CMovSOpcode"/> class.
        /// </summary>
        public CMovSOpcode()
            : base("cmovs", GetOpcodeVariants())
        {
        }
        #endregion

        /// <summary>
        /// Returns the opcode variants of this opcode.
        /// </summary>
        /// <returns>An enumerable collection of <see cref="X86OpcodeVariant"/> objects.</returns>
        private static IEnumerable<X86OpcodeVariant> GetOpcodeVariants()
        {
            return new X86OpcodeVariant[]{
                // CMOVS reg16, reg/mem16
                new X86OpcodeVariant(
                    new byte[] { 0x0F, 0x48 },
                    new OperandDescriptor(OperandType.RegisterOperand, RegisterType.GeneralPurpose16Bit),
                    new OperandDescriptor(OperandType.RegisterOrMemoryOperand, RegisterType.GeneralPurpose16Bit)),
                // CMOVS reg32, reg/mem32
                new X86OpcodeVariant(
                    new byte[] { 0x0F, 0x48 },
                    new OperandDescriptor(OperandType.RegisterOperand, RegisterType.GeneralPurpose32Bit),
                    new OperandDescriptor(OperandType.RegisterOrMemoryOperand, RegisterType.GeneralPurpose32Bit)),
                // CMOVS reg64, reg/mem64
                new X86OpcodeVariant(
                    new byte[] { 0x0F, 0x48 },
                    new OperandDescriptor(OperandType.RegisterOperand, RegisterType.GeneralPurpose64Bit),
                    new OperandDescriptor(OperandType.RegisterOrMemoryOperand, RegisterType.GeneralPurpose64Bit)),
            };
        }
    }
}

namespace SharpAssembler.Architectures.X86
{
    partial class Instr
    {
        /// <summary>
        /// Creates a new CMOVS (Move if sign) instruction.
        /// </summary>
        /// <param name="destination">A register.</param>
        /// <param name="source">A register or memory operand.</param>
        /// <returns>The created instruction.</returns>
        public static X86Instruction CMovS(Register destination, Register source)
        {
            return X86Opcode.CMovS.CreateInstruction(new RegisterOperand(destination), new RegisterOperand(source));
        }

        /// <summary>
        /// Creates a new CMOVS (Move if sign) instruction.
        /// </summary>
        /// <param name="destination">A register.</param>
        /// <param name="source">A register or memory operand.</param>
        /// <returns>The created instruction.</returns>
        public static X86Instruction CMovS(Register destination, EffectiveAddress source)
        {
            return X86Opcode.CMovS.CreateInstruction(new RegisterOperand(destination), source);
        }
    }

    partial class X86Opcode
    {
        /// <summary>
        /// The CMOVS (Move if sign) instruction opcode.
        /// </summary>
        public static readonly X86Opcode CMovS = new CMovSOpcode();
    }
}

//////////////////////////////////////////////////////
//                     WARNING                      //
//     The contents of this file is generated.      //
//    DO NOT MODIFY, your changes will be lost!     //
//////////////////////////////////////////////////////
