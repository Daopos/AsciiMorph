using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Drawing;

namespace AsciiMorph
{
    public partial class Form1 : Form
    {
        private List<TextBox> symbolInputs = new List<TextBox>(); // List to store dynamic TextBox controls for symbol input
        private const int MaxInputs = 25; // Maximum number of symbol input fields allowed
        private int currentInputCount = 0; // Tracks current number of symbol input fields

        // Add key handling for textboxes to support using Enter key to advance
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            // Check if Enter key was pressed
            if (keyData == Keys.Enter)
            {
                // Find the active control
                Control activeControl = ActiveControl;

                // If active control is a TextBox in our symbolInputs collection
                if (activeControl is TextBox && symbolInputs.Contains(activeControl))
                {
                    int currentIndex = symbolInputs.IndexOf((TextBox)activeControl);

                    // If not the last input box
                    if (currentIndex < symbolInputs.Count - 1)
                    {
                        symbolInputs[currentIndex + 1].Focus();
                        return true; // Key handled
                    }
                    // If last input box, move to pattern input
                    else if (currentIndex == symbolInputs.Count - 1)
                    {
                        txtPattern.Focus();
                        return true; // Key handled
                    }
                }
                // If active control is pattern input, trigger generate button
                else if (activeControl == txtPattern)
                {
                    btnGenerate.PerformClick();
                    return true; // Key handled
                }
            }

            return base.ProcessCmdKey(ref msg, keyData); // Not handled
        }

        public Form1()
        {
            InitializeComponent();
            numInputsSelector.Minimum = 1; // Set minimum value for NumericUpDown control
            numInputsSelector.Value = 1; // Default to 1 input field on load
            numInputsSelector.ValueChanged += NumInputsSelector_ValueChanged; // Hook up event handlers for NumericUpDown
            numInputsSelector.KeyUp += NumInputsSelector_KeyUp; // Hook up event handlers for NumericUpDown

            // Initialize with one symbol input field
            UpdateSymbolInputs(1);
        }
        // Handles KeyUp event for numInputsSelector to update symbol inputs
        private void NumInputsSelector_KeyUp(object sender, KeyEventArgs e)
        {
            NumericUpDown numInputs = (NumericUpDown)sender;
            int value = (int)numInputs.Value;
            UpdateSymbolInputs(value); // Update input fields based on entered value
        }
        // Handles ValueChanged event for numInputsSelector to update symbol inputs
        private void NumInputsSelector_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown numInputs = (NumericUpDown)sender;
            int value = (int)numInputs.Value;

            // Show inputs if value > 0, otherwise hide panel
            if (value > 0)
            {
                UpdateSymbolInputs(value);
            }
            else
            {
                UpdateSymbolInputs(0); // Hide panel
            }
        }
        // Updates the symbol input fields based on specified count
        private void UpdateSymbolInputs(int count)
        {
            // Save existing TextBox values to preserve them
            List<string> existingValues = new List<string>();
            foreach (var input in symbolInputs)
            {
                existingValues.Add(input.Text);
            }
            // Clear current controls and list
            symbolInputPanel.Controls.Clear();
            symbolInputs.Clear();
            // If count is 0, hide panel and reset count
            if (count <= 0)
            {
                symbolInputPanel.Visible = false;
                currentInputCount = 0;
                return;
            }
            // Show panel for input fields
            symbolInputPanel.Visible = true;



            // Create specified number of input fields
            for (int i = 0; i < count; i++)
            {
                // Create a panel to hold each TextBox
                Panel inputGroup = new Panel();
                inputGroup.Size = new Size(80, 60);
                inputGroup.BackColor = Color.Transparent;

                // Create and configure TextBox for symbol input
                TextBox txtSymbol = new TextBox();
                txtSymbol.Name = $"txtSymbol{i}";
                txtSymbol.Location = new Point(30, 10);
                txtSymbol.Size = new Size(40, 40);
                txtSymbol.Font = new Font("Consolas", 16F, FontStyle.Bold, GraphicsUnit.Point);
                txtSymbol.TextAlign = HorizontalAlignment.Center;
                txtSymbol.MaxLength = 1;
                txtSymbol.BackColor = Color.White;
                txtSymbol.BorderStyle = BorderStyle.FixedSingle;

                // Restore previous value if available
                if (i < existingValues.Count)
                {
                    txtSymbol.Text = existingValues[i];
                }

                // Add auto-focus functionality using TextChanged event
                int currentIndex = i;
                txtSymbol.TextChanged += (sender, e) => {
                    // Only auto-advance if text was added (not deleted)
                    TextBox currentBox = (TextBox)sender;
                    if (currentBox.Text.Length == 1 && currentIndex < symbolInputs.Count - 1)
                    {
                        // Move focus to next input box
                        symbolInputs[currentIndex + 1].Focus();
                    }
                    else if (currentBox.Text.Length == 1 && currentIndex == symbolInputs.Count - 1)
                    {
                        // If this is the last input box, move focus to the pattern input
                        txtPattern.Focus();
                    }
                };

                // Add KeyDown event handler to handle Backspace navigation
                txtSymbol.KeyDown += (sender, e) => {
                    TextBox currentBox = (TextBox)sender;

                    // Check if Backspace was pressed when textbox is empty
                    if (e.KeyCode == Keys.Back && string.IsNullOrEmpty(currentBox.Text))
                    {
                        // If not the first input box, move to previous input box
                        if (currentIndex > 0)
                        {
                            symbolInputs[currentIndex - 1].Focus();
                            // Place cursor at the end of the text in the previous textbox
                            symbolInputs[currentIndex - 1].SelectionStart = symbolInputs[currentIndex - 1].Text.Length;
                            e.Handled = true; // Mark as handled
                        }
                        // If this is the first input box and pattern input has focus, do nothing special
                    }
                };

                // Add TextBox to panel and panel to FlowLayoutPanel
                inputGroup.Controls.Add(txtSymbol);
                symbolInputPanel.Controls.Add(inputGroup);
                symbolInputs.Add(txtSymbol);
            }

            // Add KeyDown event handler for pattern input to handle Backspace navigation
            txtPattern.KeyDown += (sender, e) => {
                // Check if Backspace was pressed when textbox is empty
                if (e.KeyCode == Keys.Back && string.IsNullOrEmpty(txtPattern.Text) && symbolInputs.Count > 0)
                {
                    // Move to the last symbol input box
                    symbolInputs[symbolInputs.Count - 1].Focus();
                    // Place cursor at the end of the text
                    symbolInputs[symbolInputs.Count - 1].SelectionStart = symbolInputs[symbolInputs.Count - 1].Text.Length;
                    e.Handled = true; // Mark as handled
                }
            };

            // Update current input count
            currentInputCount = count;

            // Set focus to first empty input box if available
            for (int i = 0; i < symbolInputs.Count; i++)
            {
                if (string.IsNullOrEmpty(symbolInputs[i].Text))
                {
                    symbolInputs[i].Focus();
                    break;
                }
            }
        }

        // Handles Click event for btnGenerate to process inputs and generate output
        private void btnGenerate_Click(object sender, EventArgs e)
        {
            // Check if any input fields exist
            if (symbolInputs.Count == 0)
            {
                MessageBox.Show("Please select the number of symbols first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validate and collect input symbols
            List<char> inputSymbols = new List<char>();

            for (int i = 0; i < symbolInputs.Count; i++)
            {
                if (string.IsNullOrEmpty(symbolInputs[i].Text))
                {
                    MessageBox.Show($"Please enter a symbol in input {i + 1}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (symbolInputs[i].Text.Length != 1)
                {
                    MessageBox.Show($"Input {i + 1} must contain exactly one symbol.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                inputSymbols.Add(symbolInputs[i].Text[0]);
            }

            // Validate pattern input
            if (!int.TryParse(txtPattern.Text.Trim(), out int pattern))
            {
                MessageBox.Show("Please enter a valid number for the pattern.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Generate output and debug information
            (string result, string debug) = GenerateOutputWithDebug(inputSymbols, pattern);

            // Display result in output label
            lblOutput.Text = result;
        }
        // Generates ASCII output and debug info based on input symbols and pattern
        private (string, string) GenerateOutputWithDebug(List<char> inputSymbols, int pattern)
        {
            // Return empty result if no symbols provided
            if (inputSymbols.Count == 0)
                return ("", "");

            // Custom ASCII table mapping codes to symbols - REMOVED space, DEL, and "none" entries
            Dictionary<int, string> customAscii = new Dictionary<int, string>()
            {
                {33, "!"}, {34, "\""}, {35, "#"}, {36, "$"}, {37, "%"}, {38, "&"}, {39, "'"},
                {40, "("}, {41, ")"}, {42, "*"}, {43, "+"}, {44, ","}, {45, "-"}, {46, "."}, {47, "/"},
                {48, "0"}, {49, "1"}, {50, "2"}, {51, "3"}, {52, "4"}, {53, "5"}, {54, "6"}, {55, "7"},
                {56, "8"}, {57, "9"}, {58, ":"}, {59, ";"}, {61, "="}, {62, ">"}, {63, "?"},
                {64, "@"}, {65, "A"}, {66, "B"}, {67, "C"}, {68, "D"}, {69, "E"}, {70, "F"}, {71, "G"},
                {72, "H"}, {73, "I"}, {74, "J"}, {75, "K"}, {76, "L"}, {77, "M"}, {78, "N"}, {79, "O"},
                {80, "P"}, {81, "Q"}, {82, "R"}, {83, "S"}, {84, "T"}, {85, "U"}, {86, "V"}, {87, "W"},
                {88, "X"}, {89, "Y"}, {90, "Z"}, {91, "["}, {92, "\\"}, {93, "]"}, {94, "^"}, {95, "_"},
                {97, "a"}, {98, "b"}, {99, "c"}, {100, "d"}, {101, "e"}, {102, "f"}, {103, "g"},
                {104, "h"}, {105, "i"}, {106, "j"}, {107, "k"}, {108, "l"}, {109, "m"}, {110, "n"}, {111, "o"},
                {112, "p"}, {113, "q"}, {114, "r"}, {115, "s"}, {116, "t"}, {117, "u"}, {118, "v"}, {119, "w"},
                {120, "x"}, {121, "y"}, {122, "z"}, {123, "{"}, {124, "|"}, {125, "}"}, {126, "~"},
                {128, "€"}, {130, "‚"}, {131, "ƒ"}, {132, "„"}, {133, "…"}, {134, "†"}, {135, "‡"},
                {136, "ˆ"}, {137, "‰"}, {138, "Š"}, {139, "‹"}, {140, "Œ"}, {142, "Ž"},
                {145, "'"}, {146, "'"}, {147, """}, {148, """}, {149, "•"}, {150, "–"}, {151, "—"},
                {152, "˜"}, {153, "™"}, {154, "š"}, {155, "›"}, {156, "œ"}, {158, "ž"}, {159, "Ÿ"},
                {161, "¡"}, {162, "¢"}, {163, "£"}, {164, "¤"}, {165, "¥"}, {166, "¦"}, {167, "§"},
                {168, "¨"}, {169, "©"}, {170, "ª"}, {171, "«"}, {172, "¬"}, {174, "®"}, {175, "¯"},
                {176, "°"}, {177, "±"}, {178, "²"}, {179, "³"}, {180, "´"}, {181, "µ"}, {182, "¶"}, {183, "·"},
                {184, "¸"}, {185, "¹"}, {186, "º"}, {187, "»"}, {188, "¼"}, {189, "½"}, {190, "¾"}, {191, "¿"},
                {192, "À"}, {193, "Á"}, {194, "Â"}, {195, "Ã"}, {196, "Ä"}, {197, "Å"}, {198, "Æ"}, {199, "Ç"},
                {200, "È"}, {201, "É"}, {202, "Ê"}, {203, "Ë"}, {204, "Ì"}, {205, "Í"}, {206, "Î"}, {207, "Ï"},
                {208, "Ð"}, {209, "Ñ"}, {210, "Ò"}, {211, "Ó"}, {212, "Ô"}, {213, "Õ"}, {214, "Ö"}, {215, "×"},
                {216, "Ø"}, {217, "Ù"}, {218, "Ú"}, {219, "Û"}, {220, "Ü"}, {221, "Ý"}, {222, "Þ"}, {223, "ß"},
                {224, "à"}, {225, "á"}, {226, "â"}, {227, "ã"}, {228, "ä"}, {229, "å"}, {230, "æ"}, {231, "ç"},
                {232, "è"}, {233, "é"}, {234, "ê"}, {235, "ë"}, {236, "ì"}, {237, "í"}, {238, "î"}, {239, "ï"},
                {240, "ð"}, {241, "ñ"}, {242, "ò"}, {243, "ó"}, {244, "ô"}, {245, "õ"}, {246, "ö"}, {247, "÷"},
                {248, "ø"}, {249, "ù"}, {250, "ú"}, {251, "û"}, {252, "ü"}, {253, "ý"}, {254, "þ"}, {255, "ÿ"},
            };

            // Create reverse lookup for valid symbols
            Dictionary<string, int> customAsciiReverse = new Dictionary<string, int>();
            foreach (var pair in customAscii)
            {
                customAsciiReverse[pair.Value] = pair.Key;
            }
            // Initialize result and debug strings
            string result = "";
            string debug = "";

            // Process first character
            char firstChar = inputSymbols[0];
            string firstStr = firstChar.ToString();
            if (!customAsciiReverse.ContainsKey(firstStr))
                return ("Invalid input symbol: " + firstStr, "");

            int firstAscii = customAsciiReverse[firstStr];
            // Apply pattern to first character and ensure valid ASCII
            int firstResultAscii = EnsureValidCustomAscii(firstAscii + pattern, customAscii);

            // Append result and log debug info
            result += customAscii[firstResultAscii];
            debug += $"First: '{firstStr}' ({firstAscii}) + {pattern} → '{customAscii[firstResultAscii]}' ({firstResultAscii})\r\n";

            // Track previous result for next iteration
            int previousResultAscii = firstResultAscii;

            // Process remaining characters
            for (int i = 1; i < inputSymbols.Count; i++)
            {
                string currentStr = inputSymbols[i].ToString();
                if (!customAsciiReverse.ContainsKey(currentStr))
                    return ("Invalid input symbol: " + currentStr, "");

                int currentAscii = customAsciiReverse[currentStr];
                int newAscii;

                // Second character: add distance to its ASCII
                if (i == 1)
                {
                    int distance = Math.Abs(previousResultAscii - currentAscii);
                    newAscii = currentAscii + distance;
                }
                // Subsequent characters: use absolute difference
                else
                {
                    newAscii = Math.Abs(previousResultAscii - currentAscii);
                }

                // Ensure valid ASCII value
                newAscii = EnsureValidCustomAscii(newAscii, customAscii);

                // Append result and log debug info
                result += customAscii[newAscii];
                debug += $"Char {i}: '{currentStr}' ({currentAscii}) → '{customAscii[newAscii]}' ({newAscii})\r\n";

                // Update previous result
                previousResultAscii = newAscii;
            }

            // Return result and debug info
            return (result, debug);
        }

        // Ensures ASCII value is valid and maps to a symbol in our dictionary
        private int EnsureValidCustomAscii(int asciiValue, Dictionary<int, string> customAscii)
        {
            // If the ASCII value is already valid, return it
            if (customAscii.ContainsKey(asciiValue))
                return asciiValue;

            // Find the minimum valid ASCII code in our dictionary (should be 33 for '!')
            int minAscii = customAscii.Keys.Min();

            // Find how much we need to offset from the minimum valid code
            int offset = asciiValue - minAscii;

            // If offset is negative, make it positive (for absolute value cases)
            if (offset < 0)
                offset = Math.Abs(offset);

            // Start from minimum valid ASCII and add the offset
            int startValue = minAscii + (offset % (255 - minAscii + 1));

            // If the starting point isn't valid, find the next valid value
            while (!customAscii.ContainsKey(startValue))
            {
                startValue++;
                // If we reach the end of the ASCII range, wrap around to the beginning of our valid range
                if (startValue > 255)
                    startValue = minAscii;
            }

            return startValue;
        }

        // Handles the Clear button click event
        private void BtnClear_Click(object sender, EventArgs e)
        {
            // Clear all input fields
            ClearAllInputs();
        }

        // Method to clear all inputs and reset the form
        public void ClearAllInputs()
        {
            // Clear all symbol input fields
            foreach (var input in symbolInputs)
            {
                input.Text = string.Empty;
            }

            // Clear pattern input
            txtPattern.Text = string.Empty;

            // Clear output
            lblOutput.Text = string.Empty;

            // Set focus to the first input field if available
            if (symbolInputs.Count > 0)
            {
                symbolInputs[0].Focus();
            }
        }
    }
}