﻿namespace CleanArchitcure.Domain.Model;

public class Employee
{
	public int Id { get; set; }
	public string Name { get; set; }=string.Empty;
	public string Email { get; set; } = string.Empty;
	public string Phone {  get; set; } = string.Empty;
	public string Address {  get; set; } = string.Empty;
}
