package com.poc.challenge.questions.challengequestion.dto;

import java.util.Map;

public class UserRegistrationDto {
	
	private String username;

	private String email;

	private String password;
	
	public Map<String, String> secQA;

	public String getUsername() {
		return username;
	}

	public void setUsername(String username) {
		this.username = username;
	}

	public String getEmail() {
		return email;
	}

	public void setEmail(String email) {
		this.email = email;
	}

	public String getPassword() {
		return password;
	}

	public void setPassword(String password) {
		this.password = password;
	}

	public Map<String, String> getSecQA() {
		return secQA;
	}

	public void setSecQA(Map<String, String> secQA) {
		this.secQA = secQA;
	}
}
