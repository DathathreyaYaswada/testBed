package com.poc.challenge.questions.challengequestion.service;

import com.poc.challenge.questions.challengequestion.dto.RegisterUserDto;
import com.poc.challenge.questions.challengequestion.dto.UserDto;
import com.poc.challenge.questions.challengequestion.dto.UserRegistrationDto;
import com.poc.challenge.questions.challengequestion.model.SecQA;
import com.poc.challenge.questions.challengequestion.model.User;
import com.poc.challenge.questions.challengequestion.repository.SecQARepository;
import com.poc.challenge.questions.challengequestion.repository.UserRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.Map;

@Service
public class UserService {
	
	@Autowired
    private UserRepository userRepository;
	
	@Autowired
    private SecQARepository secQARepository;
	
	public void registerNewUser(RegisterUserDto userRegistrationDto) throws Exception {
		if (userExist(userRegistrationDto.getUsername())) {
            throw new Exception("User with name '" + userRegistrationDto.getUsername() + "' already exists.");
        }
		
		User user = new User();
		user.setUsername(userRegistrationDto.getUsername());
		user.setPassword(userRegistrationDto.getPassword());
		user.setEmail(userRegistrationDto.getEmail());
		userRepository.save(user);
		SecQA secQA1 = new SecQA(user, userRegistrationDto.getQuestion1(),userRegistrationDto.getAnswer1());
		secQARepository.save(secQA1);
		SecQA secQA2 = new SecQA(user, userRegistrationDto.getQuestion2(),userRegistrationDto.getAnswer2());
		secQARepository.save(secQA2);
		
//		Map<String, String> qa = userRegistrationDto.secQA;
//		if(qa != null) {
//        	for (Map.Entry<String, String> entry: qa.entrySet()) {
//        		SecQA secQA = new SecQA(user, entry.getKey(), entry.getValue());
//        		secQARepository.save(secQA);
//        	}
//        }
	}
	
	private boolean userExist(String name) {
        final User user = userRepository.findByName(name);
        return user != null;
    }

	public boolean validateUser(UserDto user) {
		User existingUser = userRepository.findByName(user.getUsername());
		System.out.println(user.getPassword() +" "+ existingUser.getPassword());
		if (existingUser!= null && existingUser.getPassword().equals(user.getPassword())) {
			return true;
		}
		return false;
	}
}
