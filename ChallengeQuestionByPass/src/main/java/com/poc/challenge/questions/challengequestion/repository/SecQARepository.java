package com.poc.challenge.questions.challengequestion.repository;


import com.poc.challenge.questions.challengequestion.model.SecQA;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.CrudRepository;
import org.springframework.data.repository.query.Param;

import java.util.List;

public interface SecQARepository extends CrudRepository<SecQA, Long> {

	@Query("SELECT q.answer from SecQA q where q.id =:userId and q.question =:question")
	String findAnswerByQuestionAndUserId(@Param("question") String question, @Param("userId") Long userId);
	@Query("SELECT q from SecQA q where q.question =:question ")
	SecQA findByQuestion(@Param("question") String question);

}
