package com.poc.challenge.questions.challengequestion.controller;

import java.util.Arrays;
import java.util.Collections;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import com.poc.challenge.questions.challengequestion.dto.ForgotUserDto;
import com.poc.challenge.questions.challengequestion.dto.RegisterUserDto;
import com.poc.challenge.questions.challengequestion.dto.UserDto;
import com.poc.challenge.questions.challengequestion.dto.UserRegistrationDto;
import com.poc.challenge.questions.challengequestion.model.SecQA;
import com.poc.challenge.questions.challengequestion.model.User;
import com.poc.challenge.questions.challengequestion.repository.SecQARepository;
import com.poc.challenge.questions.challengequestion.repository.UserRepository;
import com.poc.challenge.questions.challengequestion.service.UserService;
import jakarta.servlet.http.HttpServletRequest;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;
import org.springframework.web.servlet.ModelAndView;

@RestController
public class UserController {


    @Autowired
    private UserService userService;
    
    @Autowired
    private UserRepository userRepository;
    @Autowired
    private SecQARepository secQARepository;



    @GetMapping("/") public ModelAndView home() {
         return new ModelAndView("index");
     }
    @GetMapping("/login")
    public ModelAndView login() {
        return new ModelAndView("login");
    }

    
    @PostMapping("/validateUser")
    public ModelAndView loginUser(@ModelAttribute("user") UserDto user) {
    	boolean isValidUser = userService.validateUser(user);
    	if(isValidUser) return new ModelAndView("success");
    	else return new ModelAndView("failure");
    	
    }
    
    @GetMapping("/registerUser")
    public ModelAndView registerUser() {
        Map<String, String> model = getSecurityQuestions();
        return new ModelAndView("registration", "model",model);
    }

    private Map<String,String> getSecurityQuestions() {
        Map<String, String> securityQuestions = new HashMap<>();
        securityQuestions.put("question1", "What is your favourite city?");
        securityQuestions.put("question2", "What is your first pet name?");
        return securityQuestions;
    }

    @PostMapping("/submitRegistration")
    public ModelAndView registerUser(@ModelAttribute("registeruserdto") RegisterUserDto registerUserDto) throws Exception {
        Map<String, String> model = getSecurityQuestions();
        registerUserDto.setQuestion1(model.get("question1"));
        registerUserDto.setQuestion2(model.get("question2"));
        userService.registerNewUser(registerUserDto);
        return new ModelAndView("redirect:/login");
        //to do : error handling
    }
    
    @GetMapping("/forgotPassword")
    public ModelAndView forgotPassword() {
        List<String> qs = Arrays.asList("What is your favourite city?", "What is your first pet name?");
        Collections.shuffle(qs);
        final Map<String, Object> model = new HashMap<>();
        //model.put("username","");
        model.put("question", qs.get(0));
        return new ModelAndView("resetPassword", "model",model);
    }
    
    @PostMapping("/resetPassword")
    public ModelAndView resetPassword(@ModelAttribute("forgotUser") ForgotUserDto forgotUser)
    {
        final User user = userRepository.findByName(forgotUser.getUsername());
        if (user == null) {
            throw new IllegalArgumentException(forgotUser.getUsername());
        }

        String actualAnswer = secQARepository.findAnswerByQuestionAndUserId(forgotUser.getQuestion(), user.getId());

        if(forgotUser.getAnswer() != null || actualAnswer.equals(forgotUser.getAnswer())) {
            user.setPassword(forgotUser.getNewPassword());
            userRepository.save(user);
            return new ModelAndView("redirect:/login");
        }

        return new ModelAndView("invalidresponse");
    }
}
