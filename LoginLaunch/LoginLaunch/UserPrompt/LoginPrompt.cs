﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using LoginLaunch.CustomException;

namespace LoginLaunch.UserPrompt
{
    public class LoginPrompt : Prompt
    {
        private string? email { get; set; }
        private string password { get; set; } = string.Empty;

        public bool Login()
        {
            try
            {
                //get the email from user input
                this.email = getEmail();

                //check if the email exists in JSON file
                if (checkEmailInJson(this.email))
                {

                    //retrieve and set the password associated with the email
                    setPassword(this.email);

                    //get the user's entered password
                    string confirmPassword = getPassword();

                    //check if the entered password matches the stores password
                    if(validate.isEqualStrings(this.password, confirmPassword))
                    {
                        //successful login
                        return true;
                    }
                    else
                    {
                        //incorrect password throw an exception
                        throw new IncorrectPasswordException("***The password you have entered is incorrect");
                    }
                }
                else
                {
                    //email not found in JSON, throw an exception
                    throw new AccountDoesNotExist($"***Account associated with {this.email} does not exist");
                }

            }catch(EmptyOrNullString e){

                Console.WriteLine(e.Message);
                return false;
            }
            catch(AccountDoesNotExist e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            catch(IncorrectPasswordException e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            catch (Exception)
            {
                Console.WriteLine("***An unexpected error occurred");
                return false;
            }
        }

        public string getEmail()
        {
            //prompt and get the email from the user
            return validate.getString();
        }

        public string getPassword()
        {
            //prompt and get the password from the user
            return validate.getString();
        }

        public void setPassword(string email)
        {
            //retrieve and set the password associated with the given email
            this.password = getPasswordFromJson(email);
        }
    }
}
