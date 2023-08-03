package com.poc.challenge.questions.challengequestion.repository;


import com.poc.challenge.questions.challengequestion.model.User;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.CrudRepository;
import org.springframework.data.repository.query.Param;

public interface UserRepository extends CrudRepository<User, Long> {
	@Query("SELECT u from User u where u.username =:username ")
	User findByName(@Param("username") String username);

}