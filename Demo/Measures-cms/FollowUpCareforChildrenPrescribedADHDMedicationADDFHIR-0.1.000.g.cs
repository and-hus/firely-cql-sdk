﻿using System;
using Tuples;
using System.Linq;
using System.Collections.Generic;
using Hl7.Cql.Runtime;
using Hl7.Cql.Primitives;
using Hl7.Cql.Abstractions;
using Hl7.Cql.ValueSets;
using Hl7.Cql.Iso8601;
using System.Reflection;
using Hl7.Fhir.Model;
using Range = Hl7.Fhir.Model.Range;
using Task = Hl7.Fhir.Model.Task;
[System.CodeDom.Compiler.GeneratedCode(".NET Code Generation", "2.0.0.0")]
[CqlLibrary("FollowUpCareforChildrenPrescribedADHDMedicationADDFHIR", "0.1.000")]
public class FollowUpCareforChildrenPrescribedADHDMedicationADDFHIR_0_1_000
{


    internal CqlContext context;

    #region Cached values

    internal Lazy<CqlValueSet> __Ambulatory;
    internal Lazy<CqlValueSet> __Atomoxetine;
    internal Lazy<CqlValueSet> __Behavioral_Health_Follow_up_Visit;
    internal Lazy<CqlValueSet> __Clonidine;
    internal Lazy<CqlValueSet> __Dexmethylphenidate;
    internal Lazy<CqlValueSet> __Dextroamphetamine;
    internal Lazy<CqlValueSet> __Encounter_Inpatient;
    internal Lazy<CqlValueSet> __Guanfacine;
    internal Lazy<CqlValueSet> __Home_Healthcare_Services;
    internal Lazy<CqlValueSet> __Initial_Hospital_Observation_Care;
    internal Lazy<CqlValueSet> __Lisdexamfetamine;
    internal Lazy<CqlValueSet> __Mental_Behavioral_and_Neurodevelopmental_Disorders;
    internal Lazy<CqlValueSet> __Methylphenidate;
    internal Lazy<CqlValueSet> __Narcolepsy;
    internal Lazy<CqlValueSet> __Office_Visit;
    internal Lazy<CqlValueSet> __Online_Assessments;
    internal Lazy<CqlValueSet> __Outpatient_Consultation;
    internal Lazy<CqlValueSet> __Preventive_Care_Services_Group_Counseling;
    internal Lazy<CqlValueSet> __Preventive_Care_Services_Individual_Counseling;
    internal Lazy<CqlValueSet> __Preventive_Care_Services__Initial_Office_Visit__0_to_17;
    internal Lazy<CqlValueSet> __Preventive_Care__Established_Office_Visit__0_to_17;
    internal Lazy<CqlValueSet> __Psych_Visit_Diagnostic_Evaluation;
    internal Lazy<CqlValueSet> __Psych_Visit_Psychotherapy;
    internal Lazy<CqlValueSet> __Psychotherapy_and_Pharmacologic_Management;
    internal Lazy<CqlValueSet> __Telephone_Visits;
    internal Lazy<CqlCode> ___24_HR_dexmethylphenidate_hydrochloride_40_MG_Extended_Release_Oral_Capsule;
    internal Lazy<CqlCode> __methamphetamine_hydrochloride_5_MG_Oral_Tablet;
    internal Lazy<CqlCode[]> __RXNORM;
    internal Lazy<CqlInterval<CqlDateTime>> __Measurement_Period;
    internal Lazy<Patient> __Patient;
    internal Lazy<CqlDateTime> __March_1_of_Year_Prior_to_Measurement_Period;
    internal Lazy<CqlDateTime> __Last_Calendar_Day_of_February_of_Measurement_Period;
    internal Lazy<CqlInterval<CqlDateTime>> __Intake_Period;
    internal Lazy<IEnumerable<Tuple_CVELXTjiMTaGQEjMfJXBdUHjW>> __ADHD_Medication_Prescribed_During_Intake_Period_and_Not_Previously_on_ADHD_Medication;
    internal Lazy<CqlDate> __First_ADHD_Medication_Prescribed_During_Intake_Period;
    internal Lazy<CqlDate> __IPSD;
    internal Lazy<IEnumerable<Encounter>> __Qualifying_Encounter;
    internal Lazy<IEnumerable<Encounter>> __Inpatient_Stay_with_Qualifying_Diagnosis;
    internal Lazy<IEnumerable<Encounter>> __Inpatient_Stay_with_Qualifying_Diagnosis_During_Initiation_Phase;
    internal Lazy<bool?> __Initial_Population_1;
    internal Lazy<bool?> __Denominator_1;
    internal Lazy<IEnumerable<Condition>> __Narcolepsy_Exclusion;
    internal Lazy<bool?> __Denominator_Exclusions;
    internal Lazy<IEnumerable<Encounter>> __Qualifying_Numerator_Encounter;
    internal Lazy<IEnumerable<Encounter>> __Encounter_During_Initiation_Phase;
    internal Lazy<bool?> __Numerator_1;
    internal Lazy<IEnumerable<CqlInterval<CqlDate>>> __ADHD_Medications_Taken_on_IPSD_or_During_Continuation_and_Maintenance_Phase;
    internal Lazy<int?> __ADHD_Cumulative_Medication_Duration;
    internal Lazy<bool?> __Has_ADHD_Cumulative_Medication_Duration_Greater_Than_or_Equal_to_210_Days;
    internal Lazy<IEnumerable<Encounter>> __Inpatient_Stay_with_Qualifying_Diagnosis_During_Continuation_and_Maintenance_Phase;
    internal Lazy<bool?> __Initial_Population_2;
    internal Lazy<bool?> __Denominator_2;
    internal Lazy<IEnumerable<CqlDate>> __Encounter_31_to_300_Days_into_Continuation_and_Maintenance_Phase;
    internal Lazy<bool?> __Two_or_More_Encounters_31_to_300_Days_into_Continuation_and_Maintenance_Phase;
    internal Lazy<IEnumerable<CqlDate>> __Online_Assessment_31_to_300_Days_into_Continuation_and_Maintenance_Phase;
    internal Lazy<bool?> __Numerator_2;
    internal Lazy<Tuple_HPcCiDPXQfZTXIORThMLfTQDR> __SDE_Ethnicity;
    internal Lazy<IEnumerable<Tuple_GPRWMPNAYaJRiGDFSTLJOPeIJ>> __SDE_Payer;
    internal Lazy<Tuple_HPcCiDPXQfZTXIORThMLfTQDR> __SDE_Race;
    internal Lazy<CqlCode> __SDE_Sex;

    #endregion
    public FollowUpCareforChildrenPrescribedADHDMedicationADDFHIR_0_1_000(CqlContext context)
    {
        this.context = context ?? throw new ArgumentNullException("context");

        FHIRHelpers_4_3_000 = new FHIRHelpers_4_3_000(context);
        SupplementalDataElements_3_4_000 = new SupplementalDataElements_3_4_000(context);
        QICoreCommon_2_0_000 = new QICoreCommon_2_0_000(context);
        CQMCommon_2_0_000 = new CQMCommon_2_0_000(context);
        Hospice_6_9_000 = new Hospice_6_9_000(context);
        CumulativeMedicationDuration_4_0_000 = new CumulativeMedicationDuration_4_0_000(context);

        __Ambulatory = new Lazy<CqlValueSet>(this.Ambulatory_Value);
        __Atomoxetine = new Lazy<CqlValueSet>(this.Atomoxetine_Value);
        __Behavioral_Health_Follow_up_Visit = new Lazy<CqlValueSet>(this.Behavioral_Health_Follow_up_Visit_Value);
        __Clonidine = new Lazy<CqlValueSet>(this.Clonidine_Value);
        __Dexmethylphenidate = new Lazy<CqlValueSet>(this.Dexmethylphenidate_Value);
        __Dextroamphetamine = new Lazy<CqlValueSet>(this.Dextroamphetamine_Value);
        __Encounter_Inpatient = new Lazy<CqlValueSet>(this.Encounter_Inpatient_Value);
        __Guanfacine = new Lazy<CqlValueSet>(this.Guanfacine_Value);
        __Home_Healthcare_Services = new Lazy<CqlValueSet>(this.Home_Healthcare_Services_Value);
        __Initial_Hospital_Observation_Care = new Lazy<CqlValueSet>(this.Initial_Hospital_Observation_Care_Value);
        __Lisdexamfetamine = new Lazy<CqlValueSet>(this.Lisdexamfetamine_Value);
        __Mental_Behavioral_and_Neurodevelopmental_Disorders = new Lazy<CqlValueSet>(this.Mental_Behavioral_and_Neurodevelopmental_Disorders_Value);
        __Methylphenidate = new Lazy<CqlValueSet>(this.Methylphenidate_Value);
        __Narcolepsy = new Lazy<CqlValueSet>(this.Narcolepsy_Value);
        __Office_Visit = new Lazy<CqlValueSet>(this.Office_Visit_Value);
        __Online_Assessments = new Lazy<CqlValueSet>(this.Online_Assessments_Value);
        __Outpatient_Consultation = new Lazy<CqlValueSet>(this.Outpatient_Consultation_Value);
        __Preventive_Care_Services_Group_Counseling = new Lazy<CqlValueSet>(this.Preventive_Care_Services_Group_Counseling_Value);
        __Preventive_Care_Services_Individual_Counseling = new Lazy<CqlValueSet>(this.Preventive_Care_Services_Individual_Counseling_Value);
        __Preventive_Care_Services__Initial_Office_Visit__0_to_17 = new Lazy<CqlValueSet>(this.Preventive_Care_Services__Initial_Office_Visit__0_to_17_Value);
        __Preventive_Care__Established_Office_Visit__0_to_17 = new Lazy<CqlValueSet>(this.Preventive_Care__Established_Office_Visit__0_to_17_Value);
        __Psych_Visit_Diagnostic_Evaluation = new Lazy<CqlValueSet>(this.Psych_Visit_Diagnostic_Evaluation_Value);
        __Psych_Visit_Psychotherapy = new Lazy<CqlValueSet>(this.Psych_Visit_Psychotherapy_Value);
        __Psychotherapy_and_Pharmacologic_Management = new Lazy<CqlValueSet>(this.Psychotherapy_and_Pharmacologic_Management_Value);
        __Telephone_Visits = new Lazy<CqlValueSet>(this.Telephone_Visits_Value);
        ___24_HR_dexmethylphenidate_hydrochloride_40_MG_Extended_Release_Oral_Capsule = new Lazy<CqlCode>(this._24_HR_dexmethylphenidate_hydrochloride_40_MG_Extended_Release_Oral_Capsule_Value);
        __methamphetamine_hydrochloride_5_MG_Oral_Tablet = new Lazy<CqlCode>(this.methamphetamine_hydrochloride_5_MG_Oral_Tablet_Value);
        __RXNORM = new Lazy<CqlCode[]>(this.RXNORM_Value);
        __Measurement_Period = new Lazy<CqlInterval<CqlDateTime>>(this.Measurement_Period_Value);
        __Patient = new Lazy<Patient>(this.Patient_Value);
        __March_1_of_Year_Prior_to_Measurement_Period = new Lazy<CqlDateTime>(this.March_1_of_Year_Prior_to_Measurement_Period_Value);
        __Last_Calendar_Day_of_February_of_Measurement_Period = new Lazy<CqlDateTime>(this.Last_Calendar_Day_of_February_of_Measurement_Period_Value);
        __Intake_Period = new Lazy<CqlInterval<CqlDateTime>>(this.Intake_Period_Value);
        __ADHD_Medication_Prescribed_During_Intake_Period_and_Not_Previously_on_ADHD_Medication = new Lazy<IEnumerable<Tuple_CVELXTjiMTaGQEjMfJXBdUHjW>>(this.ADHD_Medication_Prescribed_During_Intake_Period_and_Not_Previously_on_ADHD_Medication_Value);
        __First_ADHD_Medication_Prescribed_During_Intake_Period = new Lazy<CqlDate>(this.First_ADHD_Medication_Prescribed_During_Intake_Period_Value);
        __IPSD = new Lazy<CqlDate>(this.IPSD_Value);
        __Qualifying_Encounter = new Lazy<IEnumerable<Encounter>>(this.Qualifying_Encounter_Value);
        __Inpatient_Stay_with_Qualifying_Diagnosis = new Lazy<IEnumerable<Encounter>>(this.Inpatient_Stay_with_Qualifying_Diagnosis_Value);
        __Inpatient_Stay_with_Qualifying_Diagnosis_During_Initiation_Phase = new Lazy<IEnumerable<Encounter>>(this.Inpatient_Stay_with_Qualifying_Diagnosis_During_Initiation_Phase_Value);
        __Initial_Population_1 = new Lazy<bool?>(this.Initial_Population_1_Value);
        __Denominator_1 = new Lazy<bool?>(this.Denominator_1_Value);
        __Narcolepsy_Exclusion = new Lazy<IEnumerable<Condition>>(this.Narcolepsy_Exclusion_Value);
        __Denominator_Exclusions = new Lazy<bool?>(this.Denominator_Exclusions_Value);
        __Qualifying_Numerator_Encounter = new Lazy<IEnumerable<Encounter>>(this.Qualifying_Numerator_Encounter_Value);
        __Encounter_During_Initiation_Phase = new Lazy<IEnumerable<Encounter>>(this.Encounter_During_Initiation_Phase_Value);
        __Numerator_1 = new Lazy<bool?>(this.Numerator_1_Value);
        __ADHD_Medications_Taken_on_IPSD_or_During_Continuation_and_Maintenance_Phase = new Lazy<IEnumerable<CqlInterval<CqlDate>>>(this.ADHD_Medications_Taken_on_IPSD_or_During_Continuation_and_Maintenance_Phase_Value);
        __ADHD_Cumulative_Medication_Duration = new Lazy<int?>(this.ADHD_Cumulative_Medication_Duration_Value);
        __Has_ADHD_Cumulative_Medication_Duration_Greater_Than_or_Equal_to_210_Days = new Lazy<bool?>(this.Has_ADHD_Cumulative_Medication_Duration_Greater_Than_or_Equal_to_210_Days_Value);
        __Inpatient_Stay_with_Qualifying_Diagnosis_During_Continuation_and_Maintenance_Phase = new Lazy<IEnumerable<Encounter>>(this.Inpatient_Stay_with_Qualifying_Diagnosis_During_Continuation_and_Maintenance_Phase_Value);
        __Initial_Population_2 = new Lazy<bool?>(this.Initial_Population_2_Value);
        __Denominator_2 = new Lazy<bool?>(this.Denominator_2_Value);
        __Encounter_31_to_300_Days_into_Continuation_and_Maintenance_Phase = new Lazy<IEnumerable<CqlDate>>(this.Encounter_31_to_300_Days_into_Continuation_and_Maintenance_Phase_Value);
        __Two_or_More_Encounters_31_to_300_Days_into_Continuation_and_Maintenance_Phase = new Lazy<bool?>(this.Two_or_More_Encounters_31_to_300_Days_into_Continuation_and_Maintenance_Phase_Value);
        __Online_Assessment_31_to_300_Days_into_Continuation_and_Maintenance_Phase = new Lazy<IEnumerable<CqlDate>>(this.Online_Assessment_31_to_300_Days_into_Continuation_and_Maintenance_Phase_Value);
        __Numerator_2 = new Lazy<bool?>(this.Numerator_2_Value);
        __SDE_Ethnicity = new Lazy<Tuple_HPcCiDPXQfZTXIORThMLfTQDR>(this.SDE_Ethnicity_Value);
        __SDE_Payer = new Lazy<IEnumerable<Tuple_GPRWMPNAYaJRiGDFSTLJOPeIJ>>(this.SDE_Payer_Value);
        __SDE_Race = new Lazy<Tuple_HPcCiDPXQfZTXIORThMLfTQDR>(this.SDE_Race_Value);
        __SDE_Sex = new Lazy<CqlCode>(this.SDE_Sex_Value);
    }
    #region Dependencies

    public FHIRHelpers_4_3_000 FHIRHelpers_4_3_000 { get; }
    public SupplementalDataElements_3_4_000 SupplementalDataElements_3_4_000 { get; }
    public QICoreCommon_2_0_000 QICoreCommon_2_0_000 { get; }
    public CQMCommon_2_0_000 CQMCommon_2_0_000 { get; }
    public Hospice_6_9_000 Hospice_6_9_000 { get; }
    public CumulativeMedicationDuration_4_0_000 CumulativeMedicationDuration_4_0_000 { get; }

    #endregion

	private CqlValueSet Ambulatory_Value() => 
		new CqlValueSet("http://cts.nlm.nih.gov/fhir/ValueSet/2.16.840.1.113883.3.464.1003.122.12.1003", null);

    [CqlDeclaration("Ambulatory")]
    [CqlValueSet("http://cts.nlm.nih.gov/fhir/ValueSet/2.16.840.1.113883.3.464.1003.122.12.1003")]
	public CqlValueSet Ambulatory() => 
		__Ambulatory.Value;

	private CqlValueSet Atomoxetine_Value() => 
		new CqlValueSet("http://cts.nlm.nih.gov/fhir/ValueSet/2.16.840.1.113883.3.464.1003.1170", null);

    [CqlDeclaration("Atomoxetine")]
    [CqlValueSet("http://cts.nlm.nih.gov/fhir/ValueSet/2.16.840.1.113883.3.464.1003.1170")]
	public CqlValueSet Atomoxetine() => 
		__Atomoxetine.Value;

	private CqlValueSet Behavioral_Health_Follow_up_Visit_Value() => 
		new CqlValueSet("http://cts.nlm.nih.gov/fhir/ValueSet/2.16.840.1.113883.3.464.1003.101.12.1054", null);

    [CqlDeclaration("Behavioral Health Follow up Visit")]
    [CqlValueSet("http://cts.nlm.nih.gov/fhir/ValueSet/2.16.840.1.113883.3.464.1003.101.12.1054")]
	public CqlValueSet Behavioral_Health_Follow_up_Visit() => 
		__Behavioral_Health_Follow_up_Visit.Value;

	private CqlValueSet Clonidine_Value() => 
		new CqlValueSet("http://cts.nlm.nih.gov/fhir/ValueSet/2.16.840.1.113883.3.464.1003.1171", null);

    [CqlDeclaration("Clonidine")]
    [CqlValueSet("http://cts.nlm.nih.gov/fhir/ValueSet/2.16.840.1.113883.3.464.1003.1171")]
	public CqlValueSet Clonidine() => 
		__Clonidine.Value;

	private CqlValueSet Dexmethylphenidate_Value() => 
		new CqlValueSet("http://cts.nlm.nih.gov/fhir/ValueSet/2.16.840.1.113883.3.464.1003.1172", null);

    [CqlDeclaration("Dexmethylphenidate")]
    [CqlValueSet("http://cts.nlm.nih.gov/fhir/ValueSet/2.16.840.1.113883.3.464.1003.1172")]
	public CqlValueSet Dexmethylphenidate() => 
		__Dexmethylphenidate.Value;

	private CqlValueSet Dextroamphetamine_Value() => 
		new CqlValueSet("http://cts.nlm.nih.gov/fhir/ValueSet/2.16.840.1.113883.3.464.1003.1173", null);

    [CqlDeclaration("Dextroamphetamine")]
    [CqlValueSet("http://cts.nlm.nih.gov/fhir/ValueSet/2.16.840.1.113883.3.464.1003.1173")]
	public CqlValueSet Dextroamphetamine() => 
		__Dextroamphetamine.Value;

	private CqlValueSet Encounter_Inpatient_Value() => 
		new CqlValueSet("http://cts.nlm.nih.gov/fhir/ValueSet/2.16.840.1.113883.3.666.5.307", null);

    [CqlDeclaration("Encounter Inpatient")]
    [CqlValueSet("http://cts.nlm.nih.gov/fhir/ValueSet/2.16.840.1.113883.3.666.5.307")]
	public CqlValueSet Encounter_Inpatient() => 
		__Encounter_Inpatient.Value;

	private CqlValueSet Guanfacine_Value() => 
		new CqlValueSet("http://cts.nlm.nih.gov/fhir/ValueSet/2.16.840.1.113883.3.464.1003.196.11.1252", null);

    [CqlDeclaration("Guanfacine")]
    [CqlValueSet("http://cts.nlm.nih.gov/fhir/ValueSet/2.16.840.1.113883.3.464.1003.196.11.1252")]
	public CqlValueSet Guanfacine() => 
		__Guanfacine.Value;

	private CqlValueSet Home_Healthcare_Services_Value() => 
		new CqlValueSet("http://cts.nlm.nih.gov/fhir/ValueSet/2.16.840.1.113883.3.464.1003.101.12.1016", null);

    [CqlDeclaration("Home Healthcare Services")]
    [CqlValueSet("http://cts.nlm.nih.gov/fhir/ValueSet/2.16.840.1.113883.3.464.1003.101.12.1016")]
	public CqlValueSet Home_Healthcare_Services() => 
		__Home_Healthcare_Services.Value;

	private CqlValueSet Initial_Hospital_Observation_Care_Value() => 
		new CqlValueSet("http://cts.nlm.nih.gov/fhir/ValueSet/2.16.840.1.113883.3.464.1003.101.12.1002", null);

    [CqlDeclaration("Initial Hospital Observation Care")]
    [CqlValueSet("http://cts.nlm.nih.gov/fhir/ValueSet/2.16.840.1.113883.3.464.1003.101.12.1002")]
	public CqlValueSet Initial_Hospital_Observation_Care() => 
		__Initial_Hospital_Observation_Care.Value;

	private CqlValueSet Lisdexamfetamine_Value() => 
		new CqlValueSet("http://cts.nlm.nih.gov/fhir/ValueSet/2.16.840.1.113883.3.464.1003.1174", null);

    [CqlDeclaration("Lisdexamfetamine")]
    [CqlValueSet("http://cts.nlm.nih.gov/fhir/ValueSet/2.16.840.1.113883.3.464.1003.1174")]
	public CqlValueSet Lisdexamfetamine() => 
		__Lisdexamfetamine.Value;

	private CqlValueSet Mental_Behavioral_and_Neurodevelopmental_Disorders_Value() => 
		new CqlValueSet("http://cts.nlm.nih.gov/fhir/ValueSet/2.16.840.1.113883.3.464.1003.105.12.1203", null);

    [CqlDeclaration("Mental Behavioral and Neurodevelopmental Disorders")]
    [CqlValueSet("http://cts.nlm.nih.gov/fhir/ValueSet/2.16.840.1.113883.3.464.1003.105.12.1203")]
	public CqlValueSet Mental_Behavioral_and_Neurodevelopmental_Disorders() => 
		__Mental_Behavioral_and_Neurodevelopmental_Disorders.Value;

	private CqlValueSet Methylphenidate_Value() => 
		new CqlValueSet("http://cts.nlm.nih.gov/fhir/ValueSet/2.16.840.1.113883.3.464.1003.1176", null);

    [CqlDeclaration("Methylphenidate")]
    [CqlValueSet("http://cts.nlm.nih.gov/fhir/ValueSet/2.16.840.1.113883.3.464.1003.1176")]
	public CqlValueSet Methylphenidate() => 
		__Methylphenidate.Value;

	private CqlValueSet Narcolepsy_Value() => 
		new CqlValueSet("http://cts.nlm.nih.gov/fhir/ValueSet/2.16.840.1.113883.3.464.1003.114.12.1011", null);

    [CqlDeclaration("Narcolepsy")]
    [CqlValueSet("http://cts.nlm.nih.gov/fhir/ValueSet/2.16.840.1.113883.3.464.1003.114.12.1011")]
	public CqlValueSet Narcolepsy() => 
		__Narcolepsy.Value;

	private CqlValueSet Office_Visit_Value() => 
		new CqlValueSet("http://cts.nlm.nih.gov/fhir/ValueSet/2.16.840.1.113883.3.464.1003.101.12.1001", null);

    [CqlDeclaration("Office Visit")]
    [CqlValueSet("http://cts.nlm.nih.gov/fhir/ValueSet/2.16.840.1.113883.3.464.1003.101.12.1001")]
	public CqlValueSet Office_Visit() => 
		__Office_Visit.Value;

	private CqlValueSet Online_Assessments_Value() => 
		new CqlValueSet("http://cts.nlm.nih.gov/fhir/ValueSet/2.16.840.1.113883.3.464.1003.101.12.1089", null);

    [CqlDeclaration("Online Assessments")]
    [CqlValueSet("http://cts.nlm.nih.gov/fhir/ValueSet/2.16.840.1.113883.3.464.1003.101.12.1089")]
	public CqlValueSet Online_Assessments() => 
		__Online_Assessments.Value;

	private CqlValueSet Outpatient_Consultation_Value() => 
		new CqlValueSet("http://cts.nlm.nih.gov/fhir/ValueSet/2.16.840.1.113883.3.464.1003.101.12.1008", null);

    [CqlDeclaration("Outpatient Consultation")]
    [CqlValueSet("http://cts.nlm.nih.gov/fhir/ValueSet/2.16.840.1.113883.3.464.1003.101.12.1008")]
	public CqlValueSet Outpatient_Consultation() => 
		__Outpatient_Consultation.Value;

	private CqlValueSet Preventive_Care_Services_Group_Counseling_Value() => 
		new CqlValueSet("http://cts.nlm.nih.gov/fhir/ValueSet/2.16.840.1.113883.3.464.1003.101.12.1027", null);

    [CqlDeclaration("Preventive Care Services Group Counseling")]
    [CqlValueSet("http://cts.nlm.nih.gov/fhir/ValueSet/2.16.840.1.113883.3.464.1003.101.12.1027")]
	public CqlValueSet Preventive_Care_Services_Group_Counseling() => 
		__Preventive_Care_Services_Group_Counseling.Value;

	private CqlValueSet Preventive_Care_Services_Individual_Counseling_Value() => 
		new CqlValueSet("http://cts.nlm.nih.gov/fhir/ValueSet/2.16.840.1.113883.3.464.1003.101.12.1026", null);

    [CqlDeclaration("Preventive Care Services Individual Counseling")]
    [CqlValueSet("http://cts.nlm.nih.gov/fhir/ValueSet/2.16.840.1.113883.3.464.1003.101.12.1026")]
	public CqlValueSet Preventive_Care_Services_Individual_Counseling() => 
		__Preventive_Care_Services_Individual_Counseling.Value;

	private CqlValueSet Preventive_Care_Services__Initial_Office_Visit__0_to_17_Value() => 
		new CqlValueSet("http://cts.nlm.nih.gov/fhir/ValueSet/2.16.840.1.113883.3.464.1003.101.12.1022", null);

    [CqlDeclaration("Preventive Care Services, Initial Office Visit, 0 to 17")]
    [CqlValueSet("http://cts.nlm.nih.gov/fhir/ValueSet/2.16.840.1.113883.3.464.1003.101.12.1022")]
	public CqlValueSet Preventive_Care_Services__Initial_Office_Visit__0_to_17() => 
		__Preventive_Care_Services__Initial_Office_Visit__0_to_17.Value;

	private CqlValueSet Preventive_Care__Established_Office_Visit__0_to_17_Value() => 
		new CqlValueSet("http://cts.nlm.nih.gov/fhir/ValueSet/2.16.840.1.113883.3.464.1003.101.12.1024", null);

    [CqlDeclaration("Preventive Care, Established Office Visit, 0 to 17")]
    [CqlValueSet("http://cts.nlm.nih.gov/fhir/ValueSet/2.16.840.1.113883.3.464.1003.101.12.1024")]
	public CqlValueSet Preventive_Care__Established_Office_Visit__0_to_17() => 
		__Preventive_Care__Established_Office_Visit__0_to_17.Value;

	private CqlValueSet Psych_Visit_Diagnostic_Evaluation_Value() => 
		new CqlValueSet("http://cts.nlm.nih.gov/fhir/ValueSet/2.16.840.1.113883.3.526.3.1492", null);

    [CqlDeclaration("Psych Visit Diagnostic Evaluation")]
    [CqlValueSet("http://cts.nlm.nih.gov/fhir/ValueSet/2.16.840.1.113883.3.526.3.1492")]
	public CqlValueSet Psych_Visit_Diagnostic_Evaluation() => 
		__Psych_Visit_Diagnostic_Evaluation.Value;

	private CqlValueSet Psych_Visit_Psychotherapy_Value() => 
		new CqlValueSet("http://cts.nlm.nih.gov/fhir/ValueSet/2.16.840.1.113883.3.526.3.1496", null);

    [CqlDeclaration("Psych Visit Psychotherapy")]
    [CqlValueSet("http://cts.nlm.nih.gov/fhir/ValueSet/2.16.840.1.113883.3.526.3.1496")]
	public CqlValueSet Psych_Visit_Psychotherapy() => 
		__Psych_Visit_Psychotherapy.Value;

	private CqlValueSet Psychotherapy_and_Pharmacologic_Management_Value() => 
		new CqlValueSet("http://cts.nlm.nih.gov/fhir/ValueSet/2.16.840.1.113883.3.464.1003.101.12.1055", null);

    [CqlDeclaration("Psychotherapy and Pharmacologic Management")]
    [CqlValueSet("http://cts.nlm.nih.gov/fhir/ValueSet/2.16.840.1.113883.3.464.1003.101.12.1055")]
	public CqlValueSet Psychotherapy_and_Pharmacologic_Management() => 
		__Psychotherapy_and_Pharmacologic_Management.Value;

	private CqlValueSet Telephone_Visits_Value() => 
		new CqlValueSet("http://cts.nlm.nih.gov/fhir/ValueSet/2.16.840.1.113883.3.464.1003.101.12.1080", null);

    [CqlDeclaration("Telephone Visits")]
    [CqlValueSet("http://cts.nlm.nih.gov/fhir/ValueSet/2.16.840.1.113883.3.464.1003.101.12.1080")]
	public CqlValueSet Telephone_Visits() => 
		__Telephone_Visits.Value;

	private CqlCode _24_HR_dexmethylphenidate_hydrochloride_40_MG_Extended_Release_Oral_Capsule_Value() => 
		new CqlCode("1006608", "http://www.nlm.nih.gov/research/umls/rxnorm", null, null);

    [CqlDeclaration("24 HR dexmethylphenidate hydrochloride 40 MG Extended Release Oral Capsule")]
	public CqlCode _24_HR_dexmethylphenidate_hydrochloride_40_MG_Extended_Release_Oral_Capsule() => 
		___24_HR_dexmethylphenidate_hydrochloride_40_MG_Extended_Release_Oral_Capsule.Value;

	private CqlCode methamphetamine_hydrochloride_5_MG_Oral_Tablet_Value() => 
		new CqlCode("977860", "http://www.nlm.nih.gov/research/umls/rxnorm", null, null);

    [CqlDeclaration("methamphetamine hydrochloride 5 MG Oral Tablet")]
	public CqlCode methamphetamine_hydrochloride_5_MG_Oral_Tablet() => 
		__methamphetamine_hydrochloride_5_MG_Oral_Tablet.Value;

	private CqlCode[] RXNORM_Value()
	{
		var a_ = new CqlCode[]
		{
			new CqlCode("1006608", "http://www.nlm.nih.gov/research/umls/rxnorm", null, null),
			new CqlCode("977860", "http://www.nlm.nih.gov/research/umls/rxnorm", null, null),
		};

		return a_;
	}

    [CqlDeclaration("RXNORM")]
	public CqlCode[] RXNORM() => 
		__RXNORM.Value;

	private CqlInterval<CqlDateTime> Measurement_Period_Value()
	{
		var a_ = context.Operators.DateTime(2025, 1, 1, 0, 0, 0, 0, default);
		var b_ = context.Operators.DateTime(2026, 1, 1, 0, 0, 0, 0, default);
		var c_ = context.Operators.Interval(a_, b_, true, false);
		var d_ = context.ResolveParameter("FollowUpCareforChildrenPrescribedADHDMedicationADDFHIR-0.1.000", "Measurement Period", c_);

		return (CqlInterval<CqlDateTime>)d_;
	}

    [CqlDeclaration("Measurement Period")]
	public CqlInterval<CqlDateTime> Measurement_Period() => 
		__Measurement_Period.Value;

	private Patient Patient_Value()
	{
		var a_ = context.Operators.RetrieveByValueSet<Patient>(null, null);
		var b_ = context.Operators.SingletonFrom<Patient>(a_);

		return b_;
	}

    [CqlDeclaration("Patient")]
	public Patient Patient() => 
		__Patient.Value;

	private CqlDateTime March_1_of_Year_Prior_to_Measurement_Period_Value()
	{
		var a_ = this.Measurement_Period();
		var b_ = context.Operators.Start(a_);
		var c_ = context.Operators.DateTimeComponentFrom(b_, "year");
		var d_ = context.Operators.Subtract(c_, 1);
		var e_ = context.Operators.ConvertIntegerToDecimal(0);
		var f_ = context.Operators.DateTime(d_, 3, 1, 0, 0, 0, 0, e_);

		return f_;
	}

    [CqlDeclaration("March 1 of Year Prior to Measurement Period")]
	public CqlDateTime March_1_of_Year_Prior_to_Measurement_Period() => 
		__March_1_of_Year_Prior_to_Measurement_Period.Value;

	private CqlDateTime Last_Calendar_Day_of_February_of_Measurement_Period_Value()
	{
		var a_ = this.Measurement_Period();
		var b_ = context.Operators.Start(a_);
		var c_ = context.Operators.DateTimeComponentFrom(b_, "year");
		var d_ = context.Operators.ConvertIntegerToDecimal(0);
		var e_ = context.Operators.DateTime(c_, 3, 1, 23, 59, 59, 0, d_);
		var f_ = context.Operators.Quantity(1m, "day");
		var g_ = context.Operators.Subtract(e_, f_);

		return g_;
	}

    [CqlDeclaration("Last Calendar Day of February of Measurement Period")]
	public CqlDateTime Last_Calendar_Day_of_February_of_Measurement_Period() => 
		__Last_Calendar_Day_of_February_of_Measurement_Period.Value;

	private CqlInterval<CqlDateTime> Intake_Period_Value()
	{
		var a_ = this.March_1_of_Year_Prior_to_Measurement_Period();
		var b_ = this.Last_Calendar_Day_of_February_of_Measurement_Period();
		var c_ = context.Operators.Interval(a_, b_, true, true);

		return c_;
	}

    [CqlDeclaration("Intake Period")]
	public CqlInterval<CqlDateTime> Intake_Period() => 
		__Intake_Period.Value;

	private IEnumerable<Tuple_CVELXTjiMTaGQEjMfJXBdUHjW> ADHD_Medication_Prescribed_During_Intake_Period_and_Not_Previously_on_ADHD_Medication_Value()
	{
		var a_ = this.Atomoxetine();
		var b_ = context.Operators.RetrieveByValueSet<MedicationRequest>(a_, null);
		var d_ = context.Operators.RetrieveByValueSet<MedicationRequest>(a_, null);
		var e_ = context.Operators.ListUnion<MedicationRequest>(b_, d_);
		var f_ = this.Clonidine();
		var g_ = context.Operators.RetrieveByValueSet<MedicationRequest>(f_, null);
		var i_ = context.Operators.RetrieveByValueSet<MedicationRequest>(f_, null);
		var j_ = context.Operators.ListUnion<MedicationRequest>(g_, i_);
		var k_ = context.Operators.ListUnion<MedicationRequest>(e_, j_);
		var l_ = this.Dexmethylphenidate();
		var m_ = context.Operators.RetrieveByValueSet<MedicationRequest>(l_, null);
		var o_ = context.Operators.RetrieveByValueSet<MedicationRequest>(l_, null);
		var p_ = context.Operators.ListUnion<MedicationRequest>(m_, o_);
		var q_ = context.Operators.ListUnion<MedicationRequest>(k_, p_);
		var r_ = this.Dextroamphetamine();
		var s_ = context.Operators.RetrieveByValueSet<MedicationRequest>(r_, null);
		var u_ = context.Operators.RetrieveByValueSet<MedicationRequest>(r_, null);
		var v_ = context.Operators.ListUnion<MedicationRequest>(s_, u_);
		var w_ = context.Operators.ListUnion<MedicationRequest>(q_, v_);
		var x_ = this.Lisdexamfetamine();
		var y_ = context.Operators.RetrieveByValueSet<MedicationRequest>(x_, null);
		var aa_ = context.Operators.RetrieveByValueSet<MedicationRequest>(x_, null);
		var ab_ = context.Operators.ListUnion<MedicationRequest>(y_, aa_);
		var ac_ = context.Operators.ListUnion<MedicationRequest>(w_, ab_);
		var ad_ = this.methamphetamine_hydrochloride_5_MG_Oral_Tablet();
		var ae_ = context.Operators.ToList<CqlCode>(ad_);
		var af_ = context.Operators.RetrieveByCodes<MedicationRequest>(ae_, null);
		var ah_ = context.Operators.ToList<CqlCode>(ad_);
		var ai_ = context.Operators.RetrieveByCodes<MedicationRequest>(ah_, null);
		var aj_ = context.Operators.ListUnion<MedicationRequest>(af_, ai_);
		var ak_ = context.Operators.ListUnion<MedicationRequest>(ac_, aj_);
		var al_ = this.Methylphenidate();
		var am_ = context.Operators.RetrieveByValueSet<MedicationRequest>(al_, null);
		var ao_ = context.Operators.RetrieveByValueSet<MedicationRequest>(al_, null);
		var ap_ = context.Operators.ListUnion<MedicationRequest>(am_, ao_);
		var aq_ = context.Operators.ListUnion<MedicationRequest>(ak_, ap_);
		var ar_ = this.Guanfacine();
		var as_ = context.Operators.RetrieveByValueSet<MedicationRequest>(ar_, null);
		var au_ = context.Operators.RetrieveByValueSet<MedicationRequest>(ar_, null);
		var av_ = context.Operators.ListUnion<MedicationRequest>(as_, au_);
		var aw_ = context.Operators.ListUnion<MedicationRequest>(aq_, av_);
		bool? ax_(MedicationRequest ADHDMedications)
		{
			var df_ = CumulativeMedicationDuration_4_0_000.MedicationRequestPeriod(ADHDMedications);
			var dg_ = context.Operators.Start(df_);
			var dh_ = context.Operators.ConvertDateToDateTime(dg_);
			var di_ = this.Intake_Period();
			var dj_ = context.Operators.In<CqlDateTime>(dh_, di_, null);

			return dj_;
		};
		var ay_ = context.Operators.Where<MedicationRequest>(aw_, ax_);
		var ba_ = context.Operators.RetrieveByValueSet<MedicationRequest>(a_, null);
		var bc_ = context.Operators.RetrieveByValueSet<MedicationRequest>(a_, null);
		var bd_ = context.Operators.ListUnion<MedicationRequest>(ba_, bc_);
		var bf_ = context.Operators.RetrieveByValueSet<MedicationRequest>(f_, null);
		var bh_ = context.Operators.RetrieveByValueSet<MedicationRequest>(f_, null);
		var bi_ = context.Operators.ListUnion<MedicationRequest>(bf_, bh_);
		var bj_ = context.Operators.ListUnion<MedicationRequest>(bd_, bi_);
		var bl_ = context.Operators.RetrieveByValueSet<MedicationRequest>(l_, null);
		var bn_ = context.Operators.RetrieveByValueSet<MedicationRequest>(l_, null);
		var bo_ = context.Operators.ListUnion<MedicationRequest>(bl_, bn_);
		var bp_ = context.Operators.ListUnion<MedicationRequest>(bj_, bo_);
		var br_ = context.Operators.RetrieveByValueSet<MedicationRequest>(r_, null);
		var bt_ = context.Operators.RetrieveByValueSet<MedicationRequest>(r_, null);
		var bu_ = context.Operators.ListUnion<MedicationRequest>(br_, bt_);
		var bv_ = context.Operators.ListUnion<MedicationRequest>(bp_, bu_);
		var bx_ = context.Operators.RetrieveByValueSet<MedicationRequest>(x_, null);
		var bz_ = context.Operators.RetrieveByValueSet<MedicationRequest>(x_, null);
		var ca_ = context.Operators.ListUnion<MedicationRequest>(bx_, bz_);
		var cb_ = context.Operators.ListUnion<MedicationRequest>(bv_, ca_);
		var cd_ = context.Operators.ToList<CqlCode>(ad_);
		var ce_ = context.Operators.RetrieveByCodes<MedicationRequest>(cd_, null);
		var cg_ = context.Operators.ToList<CqlCode>(ad_);
		var ch_ = context.Operators.RetrieveByCodes<MedicationRequest>(cg_, null);
		var ci_ = context.Operators.ListUnion<MedicationRequest>(ce_, ch_);
		var cj_ = context.Operators.ListUnion<MedicationRequest>(cb_, ci_);
		var cl_ = context.Operators.RetrieveByValueSet<MedicationRequest>(al_, null);
		var cn_ = context.Operators.RetrieveByValueSet<MedicationRequest>(al_, null);
		var co_ = context.Operators.ListUnion<MedicationRequest>(cl_, cn_);
		var cp_ = context.Operators.ListUnion<MedicationRequest>(cj_, co_);
		var cr_ = context.Operators.RetrieveByValueSet<MedicationRequest>(ar_, null);
		var ct_ = context.Operators.RetrieveByValueSet<MedicationRequest>(ar_, null);
		var cu_ = context.Operators.ListUnion<MedicationRequest>(cr_, ct_);
		var cv_ = context.Operators.ListUnion<MedicationRequest>(cp_, cu_);
		bool? cw_(MedicationRequest ADHDMedications)
		{
			var dk_ = CumulativeMedicationDuration_4_0_000.MedicationRequestPeriod(ADHDMedications);
			var dl_ = context.Operators.Start(dk_);
			var dm_ = context.Operators.ConvertDateToDateTime(dl_);
			var dn_ = this.Intake_Period();
			var do_ = context.Operators.In<CqlDateTime>(dm_, dn_, null);

			return do_;
		};
		var cx_ = context.Operators.Where<MedicationRequest>(cv_, cw_);
		IEnumerable<MedicationRequest> cy_(MedicationRequest ADHDMedicationOrder)
		{
			var dp_ = this.Atomoxetine();
			var dq_ = context.Operators.RetrieveByValueSet<MedicationRequest>(dp_, null);
			var ds_ = context.Operators.RetrieveByValueSet<MedicationRequest>(dp_, null);
			var dt_ = context.Operators.ListUnion<MedicationRequest>(dq_, ds_);
			var du_ = this.Clonidine();
			var dv_ = context.Operators.RetrieveByValueSet<MedicationRequest>(du_, null);
			var dx_ = context.Operators.RetrieveByValueSet<MedicationRequest>(du_, null);
			var dy_ = context.Operators.ListUnion<MedicationRequest>(dv_, dx_);
			var dz_ = context.Operators.ListUnion<MedicationRequest>(dt_, dy_);
			var ea_ = this.Dexmethylphenidate();
			var eb_ = context.Operators.RetrieveByValueSet<MedicationRequest>(ea_, null);
			var ed_ = context.Operators.RetrieveByValueSet<MedicationRequest>(ea_, null);
			var ee_ = context.Operators.ListUnion<MedicationRequest>(eb_, ed_);
			var ef_ = context.Operators.ListUnion<MedicationRequest>(dz_, ee_);
			var eg_ = this.Dextroamphetamine();
			var eh_ = context.Operators.RetrieveByValueSet<MedicationRequest>(eg_, null);
			var ej_ = context.Operators.RetrieveByValueSet<MedicationRequest>(eg_, null);
			var ek_ = context.Operators.ListUnion<MedicationRequest>(eh_, ej_);
			var el_ = context.Operators.ListUnion<MedicationRequest>(ef_, ek_);
			var em_ = this.Lisdexamfetamine();
			var en_ = context.Operators.RetrieveByValueSet<MedicationRequest>(em_, null);
			var ep_ = context.Operators.RetrieveByValueSet<MedicationRequest>(em_, null);
			var eq_ = context.Operators.ListUnion<MedicationRequest>(en_, ep_);
			var er_ = context.Operators.ListUnion<MedicationRequest>(el_, eq_);
			var es_ = this.methamphetamine_hydrochloride_5_MG_Oral_Tablet();
			var et_ = context.Operators.ToList<CqlCode>(es_);
			var eu_ = context.Operators.RetrieveByCodes<MedicationRequest>(et_, null);
			var ew_ = context.Operators.ToList<CqlCode>(es_);
			var ex_ = context.Operators.RetrieveByCodes<MedicationRequest>(ew_, null);
			var ey_ = context.Operators.ListUnion<MedicationRequest>(eu_, ex_);
			var ez_ = context.Operators.ListUnion<MedicationRequest>(er_, ey_);
			var fa_ = this.Methylphenidate();
			var fb_ = context.Operators.RetrieveByValueSet<MedicationRequest>(fa_, null);
			var fd_ = context.Operators.RetrieveByValueSet<MedicationRequest>(fa_, null);
			var fe_ = context.Operators.ListUnion<MedicationRequest>(fb_, fd_);
			var ff_ = context.Operators.ListUnion<MedicationRequest>(ez_, fe_);
			var fg_ = this.Guanfacine();
			var fh_ = context.Operators.RetrieveByValueSet<MedicationRequest>(fg_, null);
			var fj_ = context.Operators.RetrieveByValueSet<MedicationRequest>(fg_, null);
			var fk_ = context.Operators.ListUnion<MedicationRequest>(fh_, fj_);
			var fl_ = context.Operators.ListUnion<MedicationRequest>(ff_, fk_);
			bool? fm_(MedicationRequest ActiveADHDMedication)
			{
				var fq_ = CumulativeMedicationDuration_4_0_000.MedicationRequestPeriod(ActiveADHDMedication);
				var fr_ = CumulativeMedicationDuration_4_0_000.MedicationRequestPeriod(ADHDMedicationOrder);
				var fs_ = context.Operators.Start(fr_);
				var ft_ = context.Operators.ConvertDateToDateTime(fs_);
				var fu_ = context.Operators.DateFrom(ft_);
				var fv_ = context.Operators.Quantity(120m, "days");
				var fw_ = context.Operators.Subtract(fu_, fv_);
				var fy_ = context.Operators.Start(fr_);
				var fz_ = context.Operators.ConvertDateToDateTime(fy_);
				var ga_ = context.Operators.DateFrom(fz_);
				var gb_ = context.Operators.Interval(fw_, ga_, true, false);
				var gc_ = context.Operators.Overlaps(fq_, gb_, null);

				return gc_;
			};
			var fn_ = context.Operators.Where<MedicationRequest>(fl_, fm_);
			MedicationRequest fo_(MedicationRequest ActiveADHDMedication) => 
				ADHDMedicationOrder;
			var fp_ = context.Operators.Select<MedicationRequest, MedicationRequest>(fn_, fo_);

			return fp_;
		};
		var cz_ = context.Operators.SelectMany<MedicationRequest, MedicationRequest>(cx_, cy_);
		var da_ = context.Operators.ListExcept<MedicationRequest>(ay_, cz_);
		Tuple_CVELXTjiMTaGQEjMfJXBdUHjW db_(MedicationRequest QualifyingMed)
		{
			var gd_ = CumulativeMedicationDuration_4_0_000.MedicationRequestPeriod(QualifyingMed);
			var ge_ = context.Operators.Start(gd_);
			var gf_ = new Tuple_CVELXTjiMTaGQEjMfJXBdUHjW
			{
				startDate = ge_,
			};

			return gf_;
		};
		var dc_ = context.Operators.Select<MedicationRequest, Tuple_CVELXTjiMTaGQEjMfJXBdUHjW>(da_, db_);
		object dd_(Tuple_CVELXTjiMTaGQEjMfJXBdUHjW @this)
		{
			var gg_ = @this?.startDate;

			return gg_;
		};
		var de_ = context.Operators.SortBy<Tuple_CVELXTjiMTaGQEjMfJXBdUHjW>(dc_, dd_, System.ComponentModel.ListSortDirection.Ascending);

		return de_;
	}

    [CqlDeclaration("ADHD Medication Prescribed During Intake Period and Not Previously on ADHD Medication")]
	public IEnumerable<Tuple_CVELXTjiMTaGQEjMfJXBdUHjW> ADHD_Medication_Prescribed_During_Intake_Period_and_Not_Previously_on_ADHD_Medication() => 
		__ADHD_Medication_Prescribed_During_Intake_Period_and_Not_Previously_on_ADHD_Medication.Value;

	private CqlDate First_ADHD_Medication_Prescribed_During_Intake_Period_Value()
	{
		var a_ = this.ADHD_Medication_Prescribed_During_Intake_Period_and_Not_Previously_on_ADHD_Medication();
		bool? b_(Tuple_CVELXTjiMTaGQEjMfJXBdUHjW @this)
		{
			var g_ = @this?.startDate;
			var h_ = context.Operators.Not((bool?)(g_ is null));

			return h_;
		};
		var c_ = context.Operators.Where<Tuple_CVELXTjiMTaGQEjMfJXBdUHjW>(a_, b_);
		CqlDate d_(Tuple_CVELXTjiMTaGQEjMfJXBdUHjW @this)
		{
			var i_ = @this?.startDate;

			return i_;
		};
		var e_ = context.Operators.Select<Tuple_CVELXTjiMTaGQEjMfJXBdUHjW, CqlDate>(c_, d_);
		var f_ = context.Operators.First<CqlDate>(e_);

		return f_;
	}

    [CqlDeclaration("First ADHD Medication Prescribed During Intake Period")]
	public CqlDate First_ADHD_Medication_Prescribed_During_Intake_Period() => 
		__First_ADHD_Medication_Prescribed_During_Intake_Period.Value;

	private CqlDate IPSD_Value()
	{
		var a_ = this.First_ADHD_Medication_Prescribed_During_Intake_Period();

		return a_;
	}

    [CqlDeclaration("IPSD")]
	public CqlDate IPSD() => 
		__IPSD.Value;

	private IEnumerable<Encounter> Qualifying_Encounter_Value()
	{
		var a_ = this.Office_Visit();
		var b_ = context.Operators.RetrieveByValueSet<Encounter>(a_, null);
		var c_ = this.Home_Healthcare_Services();
		var d_ = context.Operators.RetrieveByValueSet<Encounter>(c_, null);
		var e_ = context.Operators.ListUnion<Encounter>(b_, d_);
		var f_ = this.Preventive_Care__Established_Office_Visit__0_to_17();
		var g_ = context.Operators.RetrieveByValueSet<Encounter>(f_, null);
		var h_ = this.Preventive_Care_Services__Initial_Office_Visit__0_to_17();
		var i_ = context.Operators.RetrieveByValueSet<Encounter>(h_, null);
		var j_ = context.Operators.ListUnion<Encounter>(g_, i_);
		var k_ = context.Operators.ListUnion<Encounter>(e_, j_);
		bool? l_(Encounter ValidEncounters)
		{
			var n_ = this.IPSD();
			var o_ = context.Operators.Quantity(6m, "months");
			var p_ = context.Operators.Subtract(n_, o_);
			var r_ = context.Operators.Interval(p_, n_, true, true);
			var s_ = r_?.low;
			var t_ = context.Operators.ConvertDateToDateTime(s_);
			var w_ = context.Operators.Subtract(n_, o_);
			var y_ = context.Operators.Interval(w_, n_, true, true);
			var z_ = y_?.high;
			var aa_ = context.Operators.ConvertDateToDateTime(z_);
			var ad_ = context.Operators.Subtract(n_, o_);
			var af_ = context.Operators.Interval(ad_, n_, true, true);
			var ag_ = af_?.lowClosed;
			var aj_ = context.Operators.Subtract(n_, o_);
			var al_ = context.Operators.Interval(aj_, n_, true, true);
			var am_ = al_?.highClosed;
			var an_ = context.Operators.Interval(t_, aa_, ag_, am_);
			var ao_ = ValidEncounters?.Period;
			var ap_ = FHIRHelpers_4_3_000.ToInterval(ao_);
			var aq_ = QICoreCommon_2_0_000.ToInterval((ap_ as object));
			var ar_ = context.Operators.IntervalIncludesInterval<CqlDateTime>(an_, aq_, "day");

			return ar_;
		};
		var m_ = context.Operators.Where<Encounter>(k_, l_);

		return m_;
	}

    [CqlDeclaration("Qualifying Encounter")]
	public IEnumerable<Encounter> Qualifying_Encounter() => 
		__Qualifying_Encounter.Value;

    [CqlDeclaration("PrincipalDiagnosis")]
	public IEnumerable<Condition> PrincipalDiagnosis(Encounter Encounter)
	{
		bool? a_(Encounter.DiagnosisComponent D)
		{
			var e_ = D?.RankElement;
			var f_ = e_?.Value;
			var g_ = context.Operators.Equal(f_, 1);

			return g_;
		};
		var b_ = context.Operators.Where<Encounter.DiagnosisComponent>((IEnumerable<Encounter.DiagnosisComponent>)Encounter?.Diagnosis, a_);
		Condition c_(Encounter.DiagnosisComponent PD)
		{
			var h_ = context.Operators.RetrieveByValueSet<Condition>(null, null);
			bool? i_(Condition C)
			{
				var l_ = C?.IdElement;
				var m_ = l_?.Value;
				var n_ = PD?.Condition;
				var o_ = n_?.ReferenceElement;
				var p_ = o_?.Value;
				var q_ = QICoreCommon_2_0_000.getId(p_);
				var r_ = context.Operators.Equal(m_, q_);

				return r_;
			};
			var j_ = context.Operators.Where<Condition>(h_, i_);
			var k_ = context.Operators.SingletonFrom<Condition>(j_);

			return k_;
		};
		var d_ = context.Operators.Select<Encounter.DiagnosisComponent, Condition>(b_, c_);

		return d_;
	}

	private IEnumerable<Encounter> Inpatient_Stay_with_Qualifying_Diagnosis_Value()
	{
		var a_ = this.Encounter_Inpatient();
		var b_ = context.Operators.RetrieveByValueSet<Encounter>(a_, null);
		bool? c_(Encounter InpatientStay)
		{
			var e_ = this.PrincipalDiagnosis(InpatientStay);
			bool? f_(Condition EncounterDiagnosis)
			{
				var i_ = EncounterDiagnosis?.Code;
				var j_ = FHIRHelpers_4_3_000.ToConcept(i_);
				var k_ = this.Mental_Behavioral_and_Neurodevelopmental_Disorders();
				var l_ = context.Operators.ConceptInValueSet(j_, k_);

				return l_;
			};
			var g_ = context.Operators.Where<Condition>(e_, f_);
			var h_ = context.Operators.Exists<Condition>(g_);

			return h_;
		};
		var d_ = context.Operators.Where<Encounter>(b_, c_);

		return d_;
	}

    [CqlDeclaration("Inpatient Stay with Qualifying Diagnosis")]
	public IEnumerable<Encounter> Inpatient_Stay_with_Qualifying_Diagnosis() => 
		__Inpatient_Stay_with_Qualifying_Diagnosis.Value;

	private IEnumerable<Encounter> Inpatient_Stay_with_Qualifying_Diagnosis_During_Initiation_Phase_Value()
	{
		var a_ = this.Inpatient_Stay_with_Qualifying_Diagnosis();
		bool? b_(Encounter InpatientStay)
		{
			var d_ = InpatientStay?.Period;
			var e_ = FHIRHelpers_4_3_000.ToInterval(d_);
			var f_ = CQMCommon_2_0_000.ToDateInterval(e_);
			var g_ = context.Operators.Start(f_);
			var h_ = this.IPSD();
			var j_ = context.Operators.Quantity(30m, "days");
			var k_ = context.Operators.Add(h_, j_);
			var l_ = context.Operators.Interval(h_, k_, false, true);
			var m_ = context.Operators.In<CqlDate>(g_, l_, "day");
			var o_ = context.Operators.Not((bool?)(h_ is null));
			var p_ = context.Operators.And(m_, o_);

			return p_;
		};
		var c_ = context.Operators.Where<Encounter>(a_, b_);

		return c_;
	}

    [CqlDeclaration("Inpatient Stay with Qualifying Diagnosis During Initiation Phase")]
	public IEnumerable<Encounter> Inpatient_Stay_with_Qualifying_Diagnosis_During_Initiation_Phase() => 
		__Inpatient_Stay_with_Qualifying_Diagnosis_During_Initiation_Phase.Value;

	private bool? Initial_Population_1_Value()
	{
		var a_ = this.Patient();
		var b_ = context.Operators.Convert<CqlDate>(a_?.BirthDateElement?.Value);
		var c_ = this.Intake_Period();
		var d_ = context.Operators.Start(c_);
		var e_ = context.Operators.DateFrom(d_);
		var f_ = context.Operators.CalculateAgeAt(b_, e_, "year");
		var g_ = context.Operators.GreaterOrEqual(f_, 6);
		var i_ = context.Operators.Convert<CqlDate>(a_?.BirthDateElement?.Value);
		var k_ = context.Operators.End(c_);
		var l_ = context.Operators.DateFrom(k_);
		var m_ = context.Operators.CalculateAgeAt(i_, l_, "year");
		var n_ = context.Operators.LessOrEqual(m_, 12);
		var o_ = context.Operators.And(g_, n_);
		var p_ = this.Qualifying_Encounter();
		var q_ = context.Operators.Exists<Encounter>(p_);
		var r_ = context.Operators.And(o_, q_);
		var s_ = this.First_ADHD_Medication_Prescribed_During_Intake_Period();
		var t_ = context.Operators.Not((bool?)(s_ is null));
		var u_ = context.Operators.And(r_, t_);
		var v_ = this.Inpatient_Stay_with_Qualifying_Diagnosis_During_Initiation_Phase();
		var w_ = context.Operators.Exists<Encounter>(v_);
		var x_ = context.Operators.Not(w_);
		var y_ = context.Operators.And(u_, x_);

		return y_;
	}

    [CqlDeclaration("Initial Population 1")]
	public bool? Initial_Population_1() => 
		__Initial_Population_1.Value;

	private bool? Denominator_1_Value()
	{
		var a_ = this.Initial_Population_1();

		return a_;
	}

    [CqlDeclaration("Denominator 1")]
	public bool? Denominator_1() => 
		__Denominator_1.Value;

	private IEnumerable<Condition> Narcolepsy_Exclusion_Value()
	{
		var a_ = this.Narcolepsy();
		var b_ = context.Operators.RetrieveByValueSet<Condition>(a_, null);
		bool? c_(Condition Narcolepsy)
		{
			var e_ = QICoreCommon_2_0_000.ToPrevalenceInterval(Narcolepsy);
			var f_ = context.Operators.Start(e_);
			var g_ = this.Measurement_Period();
			var h_ = context.Operators.End(g_);
			var i_ = context.Operators.SameOrBefore(f_, h_, null);

			return i_;
		};
		var d_ = context.Operators.Where<Condition>(b_, c_);

		return d_;
	}

    [CqlDeclaration("Narcolepsy Exclusion")]
	public IEnumerable<Condition> Narcolepsy_Exclusion() => 
		__Narcolepsy_Exclusion.Value;

	private bool? Denominator_Exclusions_Value()
	{
		var a_ = Hospice_6_9_000.Has_Hospice_Services();
		var b_ = this.Narcolepsy_Exclusion();
		var c_ = context.Operators.Exists<Condition>(b_);
		var d_ = context.Operators.Or(a_, c_);

		return d_;
	}

    [CqlDeclaration("Denominator Exclusions")]
	public bool? Denominator_Exclusions() => 
		__Denominator_Exclusions.Value;

	private IEnumerable<Encounter> Qualifying_Numerator_Encounter_Value()
	{
		var a_ = this.Office_Visit();
		var b_ = context.Operators.RetrieveByValueSet<Encounter>(a_, null);
		var c_ = this.Initial_Hospital_Observation_Care();
		var d_ = context.Operators.RetrieveByValueSet<Encounter>(c_, null);
		var e_ = context.Operators.ListUnion<Encounter>(b_, d_);
		var f_ = this.Preventive_Care_Services_Group_Counseling();
		var g_ = context.Operators.RetrieveByValueSet<Encounter>(f_, null);
		var h_ = this.Behavioral_Health_Follow_up_Visit();
		var i_ = context.Operators.RetrieveByValueSet<Encounter>(h_, null);
		var j_ = context.Operators.ListUnion<Encounter>(g_, i_);
		var k_ = context.Operators.ListUnion<Encounter>(e_, j_);
		var l_ = this.Preventive_Care_Services_Individual_Counseling();
		var m_ = context.Operators.RetrieveByValueSet<Encounter>(l_, null);
		var n_ = this.Psychotherapy_and_Pharmacologic_Management();
		var o_ = context.Operators.RetrieveByValueSet<Encounter>(n_, null);
		bool? p_(Encounter PsychPharmManagement)
		{
			var ao_ = PsychPharmManagement?.Location;
			bool? ap_(Encounter.LocationComponent Location)
			{
				var as_ = Location?.Location;
				var at_ = CQMCommon_2_0_000.GetLocation(as_);
				var au_ = at_?.Type;
				CqlConcept av_(CodeableConcept @this)
				{
					var az_ = FHIRHelpers_4_3_000.ToConcept(@this);

					return az_;
				};
				var aw_ = context.Operators.Select<CodeableConcept, CqlConcept>((IEnumerable<CodeableConcept>)au_, av_);
				var ax_ = this.Ambulatory();
				var ay_ = context.Operators.ConceptsInValueSet(aw_, ax_);

				return ay_;
			};
			var aq_ = context.Operators.Where<Encounter.LocationComponent>((IEnumerable<Encounter.LocationComponent>)ao_, ap_);
			var ar_ = context.Operators.Exists<Encounter.LocationComponent>(aq_);

			return ar_;
		};
		var q_ = context.Operators.Where<Encounter>(o_, p_);
		var r_ = context.Operators.ListUnion<Encounter>(m_, q_);
		var s_ = context.Operators.ListUnion<Encounter>(k_, r_);
		var t_ = this.Outpatient_Consultation();
		var u_ = context.Operators.RetrieveByValueSet<Encounter>(t_, null);
		var v_ = this.Home_Healthcare_Services();
		var w_ = context.Operators.RetrieveByValueSet<Encounter>(v_, null);
		var x_ = context.Operators.ListUnion<Encounter>(u_, w_);
		var y_ = context.Operators.ListUnion<Encounter>(s_, x_);
		var z_ = this.Preventive_Care_Services__Initial_Office_Visit__0_to_17();
		var aa_ = context.Operators.RetrieveByValueSet<Encounter>(z_, null);
		var ab_ = this.Preventive_Care__Established_Office_Visit__0_to_17();
		var ac_ = context.Operators.RetrieveByValueSet<Encounter>(ab_, null);
		var ad_ = context.Operators.ListUnion<Encounter>(aa_, ac_);
		var ae_ = context.Operators.ListUnion<Encounter>(y_, ad_);
		var af_ = this.Psych_Visit_Diagnostic_Evaluation();
		var ag_ = context.Operators.RetrieveByValueSet<Encounter>(af_, null);
		var ah_ = this.Psych_Visit_Psychotherapy();
		var ai_ = context.Operators.RetrieveByValueSet<Encounter>(ah_, null);
		var aj_ = context.Operators.ListUnion<Encounter>(ag_, ai_);
		var ak_ = context.Operators.ListUnion<Encounter>(ae_, aj_);
		var al_ = this.Telephone_Visits();
		var am_ = context.Operators.RetrieveByValueSet<Encounter>(al_, null);
		var an_ = context.Operators.ListUnion<Encounter>(ak_, am_);

		return an_;
	}

    [CqlDeclaration("Qualifying Numerator Encounter")]
	public IEnumerable<Encounter> Qualifying_Numerator_Encounter() => 
		__Qualifying_Numerator_Encounter.Value;

	private IEnumerable<Encounter> Encounter_During_Initiation_Phase_Value()
	{
		var a_ = this.Qualifying_Numerator_Encounter();
		bool? b_(Encounter ValidNumeratorEncounter)
		{
			var d_ = ValidNumeratorEncounter?.Period;
			var e_ = FHIRHelpers_4_3_000.ToInterval(d_);
			var f_ = CQMCommon_2_0_000.ToDateInterval(e_);
			var g_ = context.Operators.Start(f_);
			var h_ = this.IPSD();
			var j_ = context.Operators.Quantity(30m, "days");
			var k_ = context.Operators.Add(h_, j_);
			var l_ = context.Operators.Interval(h_, k_, false, true);
			var m_ = context.Operators.In<CqlDate>(g_, l_, "day");
			var o_ = context.Operators.Not((bool?)(h_ is null));
			var p_ = context.Operators.And(m_, o_);

			return p_;
		};
		var c_ = context.Operators.Where<Encounter>(a_, b_);

		return c_;
	}

    [CqlDeclaration("Encounter During Initiation Phase")]
	public IEnumerable<Encounter> Encounter_During_Initiation_Phase() => 
		__Encounter_During_Initiation_Phase.Value;

	private bool? Numerator_1_Value()
	{
		var a_ = this.Encounter_During_Initiation_Phase();
		var b_ = context.Operators.Exists<Encounter>(a_);

		return b_;
	}

    [CqlDeclaration("Numerator 1")]
	public bool? Numerator_1() => 
		__Numerator_1.Value;

	private IEnumerable<CqlInterval<CqlDate>> ADHD_Medications_Taken_on_IPSD_or_During_Continuation_and_Maintenance_Phase_Value()
	{
		var a_ = this.Atomoxetine();
		var b_ = context.Operators.RetrieveByValueSet<MedicationRequest>(a_, null);
		var d_ = context.Operators.RetrieveByValueSet<MedicationRequest>(a_, null);
		var e_ = context.Operators.ListUnion<MedicationRequest>(b_, d_);
		Tuple_EhMLLfWeOaeVhYfBZeiQfaefD f_(MedicationRequest AtomoxetineMed)
		{
			var dt_ = CumulativeMedicationDuration_4_0_000.MedicationRequestPeriod(AtomoxetineMed);
			var dv_ = context.Operators.Start(dt_);
			var dw_ = new Tuple_EhMLLfWeOaeVhYfBZeiQfaefD
			{
				period = dt_,
				periodStart = dv_,
			};

			return dw_;
		};
		var g_ = context.Operators.Select<MedicationRequest, Tuple_EhMLLfWeOaeVhYfBZeiQfaefD>(e_, f_);
		object h_(Tuple_EhMLLfWeOaeVhYfBZeiQfaefD @this)
		{
			var dx_ = @this?.periodStart;

			return dx_;
		};
		var i_ = context.Operators.SortBy<Tuple_EhMLLfWeOaeVhYfBZeiQfaefD>(g_, h_, System.ComponentModel.ListSortDirection.Ascending);
		bool? j_(Tuple_EhMLLfWeOaeVhYfBZeiQfaefD @this)
		{
			var dy_ = @this?.period;
			var dz_ = context.Operators.Not((bool?)(dy_ is null));

			return dz_;
		};
		var k_ = context.Operators.Where<Tuple_EhMLLfWeOaeVhYfBZeiQfaefD>(i_, j_);
		CqlInterval<CqlDate> l_(Tuple_EhMLLfWeOaeVhYfBZeiQfaefD @this)
		{
			var ea_ = @this?.period;

			return ea_;
		};
		var m_ = context.Operators.Select<Tuple_EhMLLfWeOaeVhYfBZeiQfaefD, CqlInterval<CqlDate>>(k_, l_);
		var n_ = CumulativeMedicationDuration_4_0_000.RolloutIntervals(m_);
		var o_ = this.Clonidine();
		var p_ = context.Operators.RetrieveByValueSet<MedicationRequest>(o_, null);
		var r_ = context.Operators.RetrieveByValueSet<MedicationRequest>(o_, null);
		var s_ = context.Operators.ListUnion<MedicationRequest>(p_, r_);
		Tuple_EhMLLfWeOaeVhYfBZeiQfaefD t_(MedicationRequest ClonidineMed)
		{
			var eb_ = CumulativeMedicationDuration_4_0_000.MedicationRequestPeriod(ClonidineMed);
			var ed_ = context.Operators.Start(eb_);
			var ee_ = new Tuple_EhMLLfWeOaeVhYfBZeiQfaefD
			{
				period = eb_,
				periodStart = ed_,
			};

			return ee_;
		};
		var u_ = context.Operators.Select<MedicationRequest, Tuple_EhMLLfWeOaeVhYfBZeiQfaefD>(s_, t_);
		object v_(Tuple_EhMLLfWeOaeVhYfBZeiQfaefD @this)
		{
			var ef_ = @this?.periodStart;

			return ef_;
		};
		var w_ = context.Operators.SortBy<Tuple_EhMLLfWeOaeVhYfBZeiQfaefD>(u_, v_, System.ComponentModel.ListSortDirection.Ascending);
		bool? x_(Tuple_EhMLLfWeOaeVhYfBZeiQfaefD @this)
		{
			var eg_ = @this?.period;
			var eh_ = context.Operators.Not((bool?)(eg_ is null));

			return eh_;
		};
		var y_ = context.Operators.Where<Tuple_EhMLLfWeOaeVhYfBZeiQfaefD>(w_, x_);
		CqlInterval<CqlDate> z_(Tuple_EhMLLfWeOaeVhYfBZeiQfaefD @this)
		{
			var ei_ = @this?.period;

			return ei_;
		};
		var aa_ = context.Operators.Select<Tuple_EhMLLfWeOaeVhYfBZeiQfaefD, CqlInterval<CqlDate>>(y_, z_);
		var ab_ = CumulativeMedicationDuration_4_0_000.RolloutIntervals(aa_);
		var ac_ = context.Operators.ListUnion<CqlInterval<CqlDate>>(n_, ab_);
		var ad_ = this.Dexmethylphenidate();
		var ae_ = context.Operators.RetrieveByValueSet<MedicationRequest>(ad_, null);
		var ag_ = context.Operators.RetrieveByValueSet<MedicationRequest>(ad_, null);
		var ah_ = context.Operators.ListUnion<MedicationRequest>(ae_, ag_);
		Tuple_EhMLLfWeOaeVhYfBZeiQfaefD ai_(MedicationRequest DexmethylphenidateMed)
		{
			var ej_ = CumulativeMedicationDuration_4_0_000.MedicationRequestPeriod(DexmethylphenidateMed);
			var el_ = context.Operators.Start(ej_);
			var em_ = new Tuple_EhMLLfWeOaeVhYfBZeiQfaefD
			{
				period = ej_,
				periodStart = el_,
			};

			return em_;
		};
		var aj_ = context.Operators.Select<MedicationRequest, Tuple_EhMLLfWeOaeVhYfBZeiQfaefD>(ah_, ai_);
		object ak_(Tuple_EhMLLfWeOaeVhYfBZeiQfaefD @this)
		{
			var en_ = @this?.periodStart;

			return en_;
		};
		var al_ = context.Operators.SortBy<Tuple_EhMLLfWeOaeVhYfBZeiQfaefD>(aj_, ak_, System.ComponentModel.ListSortDirection.Ascending);
		bool? am_(Tuple_EhMLLfWeOaeVhYfBZeiQfaefD @this)
		{
			var eo_ = @this?.period;
			var ep_ = context.Operators.Not((bool?)(eo_ is null));

			return ep_;
		};
		var an_ = context.Operators.Where<Tuple_EhMLLfWeOaeVhYfBZeiQfaefD>(al_, am_);
		CqlInterval<CqlDate> ao_(Tuple_EhMLLfWeOaeVhYfBZeiQfaefD @this)
		{
			var eq_ = @this?.period;

			return eq_;
		};
		var ap_ = context.Operators.Select<Tuple_EhMLLfWeOaeVhYfBZeiQfaefD, CqlInterval<CqlDate>>(an_, ao_);
		var aq_ = CumulativeMedicationDuration_4_0_000.RolloutIntervals(ap_);
		var ar_ = this.Dextroamphetamine();
		var as_ = context.Operators.RetrieveByValueSet<MedicationRequest>(ar_, null);
		var au_ = context.Operators.RetrieveByValueSet<MedicationRequest>(ar_, null);
		var av_ = context.Operators.ListUnion<MedicationRequest>(as_, au_);
		Tuple_EhMLLfWeOaeVhYfBZeiQfaefD aw_(MedicationRequest DextroamphetamineMed)
		{
			var er_ = CumulativeMedicationDuration_4_0_000.MedicationRequestPeriod(DextroamphetamineMed);
			var et_ = context.Operators.Start(er_);
			var eu_ = new Tuple_EhMLLfWeOaeVhYfBZeiQfaefD
			{
				period = er_,
				periodStart = et_,
			};

			return eu_;
		};
		var ax_ = context.Operators.Select<MedicationRequest, Tuple_EhMLLfWeOaeVhYfBZeiQfaefD>(av_, aw_);
		object ay_(Tuple_EhMLLfWeOaeVhYfBZeiQfaefD @this)
		{
			var ev_ = @this?.periodStart;

			return ev_;
		};
		var az_ = context.Operators.SortBy<Tuple_EhMLLfWeOaeVhYfBZeiQfaefD>(ax_, ay_, System.ComponentModel.ListSortDirection.Ascending);
		bool? ba_(Tuple_EhMLLfWeOaeVhYfBZeiQfaefD @this)
		{
			var ew_ = @this?.period;
			var ex_ = context.Operators.Not((bool?)(ew_ is null));

			return ex_;
		};
		var bb_ = context.Operators.Where<Tuple_EhMLLfWeOaeVhYfBZeiQfaefD>(az_, ba_);
		CqlInterval<CqlDate> bc_(Tuple_EhMLLfWeOaeVhYfBZeiQfaefD @this)
		{
			var ey_ = @this?.period;

			return ey_;
		};
		var bd_ = context.Operators.Select<Tuple_EhMLLfWeOaeVhYfBZeiQfaefD, CqlInterval<CqlDate>>(bb_, bc_);
		var be_ = CumulativeMedicationDuration_4_0_000.RolloutIntervals(bd_);
		var bf_ = context.Operators.ListUnion<CqlInterval<CqlDate>>(aq_, be_);
		var bg_ = context.Operators.ListUnion<CqlInterval<CqlDate>>(ac_, bf_);
		var bh_ = this.Lisdexamfetamine();
		var bi_ = context.Operators.RetrieveByValueSet<MedicationRequest>(bh_, null);
		var bk_ = context.Operators.RetrieveByValueSet<MedicationRequest>(bh_, null);
		var bl_ = context.Operators.ListUnion<MedicationRequest>(bi_, bk_);
		Tuple_EhMLLfWeOaeVhYfBZeiQfaefD bm_(MedicationRequest LisdexamfetamineMed)
		{
			var ez_ = CumulativeMedicationDuration_4_0_000.MedicationRequestPeriod(LisdexamfetamineMed);
			var fb_ = context.Operators.Start(ez_);
			var fc_ = new Tuple_EhMLLfWeOaeVhYfBZeiQfaefD
			{
				period = ez_,
				periodStart = fb_,
			};

			return fc_;
		};
		var bn_ = context.Operators.Select<MedicationRequest, Tuple_EhMLLfWeOaeVhYfBZeiQfaefD>(bl_, bm_);
		object bo_(Tuple_EhMLLfWeOaeVhYfBZeiQfaefD @this)
		{
			var fd_ = @this?.periodStart;

			return fd_;
		};
		var bp_ = context.Operators.SortBy<Tuple_EhMLLfWeOaeVhYfBZeiQfaefD>(bn_, bo_, System.ComponentModel.ListSortDirection.Ascending);
		bool? bq_(Tuple_EhMLLfWeOaeVhYfBZeiQfaefD @this)
		{
			var fe_ = @this?.period;
			var ff_ = context.Operators.Not((bool?)(fe_ is null));

			return ff_;
		};
		var br_ = context.Operators.Where<Tuple_EhMLLfWeOaeVhYfBZeiQfaefD>(bp_, bq_);
		CqlInterval<CqlDate> bs_(Tuple_EhMLLfWeOaeVhYfBZeiQfaefD @this)
		{
			var fg_ = @this?.period;

			return fg_;
		};
		var bt_ = context.Operators.Select<Tuple_EhMLLfWeOaeVhYfBZeiQfaefD, CqlInterval<CqlDate>>(br_, bs_);
		var bu_ = CumulativeMedicationDuration_4_0_000.RolloutIntervals(bt_);
		var bv_ = this.Methylphenidate();
		var bw_ = context.Operators.RetrieveByValueSet<MedicationRequest>(bv_, null);
		var by_ = context.Operators.RetrieveByValueSet<MedicationRequest>(bv_, null);
		var bz_ = context.Operators.ListUnion<MedicationRequest>(bw_, by_);
		Tuple_EhMLLfWeOaeVhYfBZeiQfaefD ca_(MedicationRequest MethylphenidateMed)
		{
			var fh_ = CumulativeMedicationDuration_4_0_000.MedicationRequestPeriod(MethylphenidateMed);
			var fj_ = context.Operators.Start(fh_);
			var fk_ = new Tuple_EhMLLfWeOaeVhYfBZeiQfaefD
			{
				period = fh_,
				periodStart = fj_,
			};

			return fk_;
		};
		var cb_ = context.Operators.Select<MedicationRequest, Tuple_EhMLLfWeOaeVhYfBZeiQfaefD>(bz_, ca_);
		object cc_(Tuple_EhMLLfWeOaeVhYfBZeiQfaefD @this)
		{
			var fl_ = @this?.periodStart;

			return fl_;
		};
		var cd_ = context.Operators.SortBy<Tuple_EhMLLfWeOaeVhYfBZeiQfaefD>(cb_, cc_, System.ComponentModel.ListSortDirection.Ascending);
		bool? ce_(Tuple_EhMLLfWeOaeVhYfBZeiQfaefD @this)
		{
			var fm_ = @this?.period;
			var fn_ = context.Operators.Not((bool?)(fm_ is null));

			return fn_;
		};
		var cf_ = context.Operators.Where<Tuple_EhMLLfWeOaeVhYfBZeiQfaefD>(cd_, ce_);
		CqlInterval<CqlDate> cg_(Tuple_EhMLLfWeOaeVhYfBZeiQfaefD @this)
		{
			var fo_ = @this?.period;

			return fo_;
		};
		var ch_ = context.Operators.Select<Tuple_EhMLLfWeOaeVhYfBZeiQfaefD, CqlInterval<CqlDate>>(cf_, cg_);
		var ci_ = CumulativeMedicationDuration_4_0_000.RolloutIntervals(ch_);
		var cj_ = context.Operators.ListUnion<CqlInterval<CqlDate>>(bu_, ci_);
		var ck_ = context.Operators.ListUnion<CqlInterval<CqlDate>>(bg_, cj_);
		var cl_ = this.Guanfacine();
		var cm_ = context.Operators.RetrieveByValueSet<MedicationRequest>(cl_, null);
		var co_ = context.Operators.RetrieveByValueSet<MedicationRequest>(cl_, null);
		var cp_ = context.Operators.ListUnion<MedicationRequest>(cm_, co_);
		Tuple_EhMLLfWeOaeVhYfBZeiQfaefD cq_(MedicationRequest GuanfacineMed)
		{
			var fp_ = CumulativeMedicationDuration_4_0_000.MedicationRequestPeriod(GuanfacineMed);
			var fr_ = context.Operators.Start(fp_);
			var fs_ = new Tuple_EhMLLfWeOaeVhYfBZeiQfaefD
			{
				period = fp_,
				periodStart = fr_,
			};

			return fs_;
		};
		var cr_ = context.Operators.Select<MedicationRequest, Tuple_EhMLLfWeOaeVhYfBZeiQfaefD>(cp_, cq_);
		object cs_(Tuple_EhMLLfWeOaeVhYfBZeiQfaefD @this)
		{
			var ft_ = @this?.periodStart;

			return ft_;
		};
		var ct_ = context.Operators.SortBy<Tuple_EhMLLfWeOaeVhYfBZeiQfaefD>(cr_, cs_, System.ComponentModel.ListSortDirection.Ascending);
		bool? cu_(Tuple_EhMLLfWeOaeVhYfBZeiQfaefD @this)
		{
			var fu_ = @this?.period;
			var fv_ = context.Operators.Not((bool?)(fu_ is null));

			return fv_;
		};
		var cv_ = context.Operators.Where<Tuple_EhMLLfWeOaeVhYfBZeiQfaefD>(ct_, cu_);
		CqlInterval<CqlDate> cw_(Tuple_EhMLLfWeOaeVhYfBZeiQfaefD @this)
		{
			var fw_ = @this?.period;

			return fw_;
		};
		var cx_ = context.Operators.Select<Tuple_EhMLLfWeOaeVhYfBZeiQfaefD, CqlInterval<CqlDate>>(cv_, cw_);
		var cy_ = CumulativeMedicationDuration_4_0_000.RolloutIntervals(cx_);
		var cz_ = this.methamphetamine_hydrochloride_5_MG_Oral_Tablet();
		var da_ = context.Operators.ToList<CqlCode>(cz_);
		var db_ = context.Operators.RetrieveByCodes<MedicationRequest>(da_, null);
		var dd_ = context.Operators.ToList<CqlCode>(cz_);
		var de_ = context.Operators.RetrieveByCodes<MedicationRequest>(dd_, null);
		var df_ = context.Operators.ListUnion<MedicationRequest>(db_, de_);
		Tuple_EhMLLfWeOaeVhYfBZeiQfaefD dg_(MedicationRequest MethamphetamineMed)
		{
			var fx_ = CumulativeMedicationDuration_4_0_000.MedicationRequestPeriod(MethamphetamineMed);
			var fz_ = context.Operators.Start(fx_);
			var ga_ = new Tuple_EhMLLfWeOaeVhYfBZeiQfaefD
			{
				period = fx_,
				periodStart = fz_,
			};

			return ga_;
		};
		var dh_ = context.Operators.Select<MedicationRequest, Tuple_EhMLLfWeOaeVhYfBZeiQfaefD>(df_, dg_);
		object di_(Tuple_EhMLLfWeOaeVhYfBZeiQfaefD @this)
		{
			var gb_ = @this?.periodStart;

			return gb_;
		};
		var dj_ = context.Operators.SortBy<Tuple_EhMLLfWeOaeVhYfBZeiQfaefD>(dh_, di_, System.ComponentModel.ListSortDirection.Ascending);
		bool? dk_(Tuple_EhMLLfWeOaeVhYfBZeiQfaefD @this)
		{
			var gc_ = @this?.period;
			var gd_ = context.Operators.Not((bool?)(gc_ is null));

			return gd_;
		};
		var dl_ = context.Operators.Where<Tuple_EhMLLfWeOaeVhYfBZeiQfaefD>(dj_, dk_);
		CqlInterval<CqlDate> dm_(Tuple_EhMLLfWeOaeVhYfBZeiQfaefD @this)
		{
			var ge_ = @this?.period;

			return ge_;
		};
		var dn_ = context.Operators.Select<Tuple_EhMLLfWeOaeVhYfBZeiQfaefD, CqlInterval<CqlDate>>(dl_, dm_);
		var do_ = CumulativeMedicationDuration_4_0_000.RolloutIntervals(dn_);
		var dp_ = context.Operators.ListUnion<CqlInterval<CqlDate>>(cy_, do_);
		var dq_ = context.Operators.ListUnion<CqlInterval<CqlDate>>(ck_, dp_);
		CqlInterval<CqlDate> dr_(CqlInterval<CqlDate> ADHDMedication)
		{
			var gf_ = this.IPSD();
			var gh_ = context.Operators.Quantity(300m, "days");
			var gi_ = context.Operators.Add(gf_, gh_);
			var gj_ = context.Operators.Interval(gf_, gi_, true, true);
			var gk_ = context.Operators.IntervalIntersect<CqlDate>(ADHDMedication, gj_);

			return gk_;
		};
		var ds_ = context.Operators.Select<CqlInterval<CqlDate>, CqlInterval<CqlDate>>(dq_, dr_);

		return ds_;
	}

    [CqlDeclaration("ADHD Medications Taken on IPSD or During Continuation and Maintenance Phase")]
	public IEnumerable<CqlInterval<CqlDate>> ADHD_Medications_Taken_on_IPSD_or_During_Continuation_and_Maintenance_Phase() => 
		__ADHD_Medications_Taken_on_IPSD_or_During_Continuation_and_Maintenance_Phase.Value;

	private int? ADHD_Cumulative_Medication_Duration_Value()
	{
		var a_ = this.ADHD_Medications_Taken_on_IPSD_or_During_Continuation_and_Maintenance_Phase();
		var b_ = CumulativeMedicationDuration_4_0_000.CumulativeDuration(a_);

		return b_;
	}

    [CqlDeclaration("ADHD Cumulative Medication Duration")]
	public int? ADHD_Cumulative_Medication_Duration() => 
		__ADHD_Cumulative_Medication_Duration.Value;

	private bool? Has_ADHD_Cumulative_Medication_Duration_Greater_Than_or_Equal_to_210_Days_Value()
	{
		var a_ = this.ADHD_Cumulative_Medication_Duration();
		var b_ = context.Operators.GreaterOrEqual(a_, 210);

		return b_;
	}

    [CqlDeclaration("Has ADHD Cumulative Medication Duration Greater Than or Equal to 210 Days")]
	public bool? Has_ADHD_Cumulative_Medication_Duration_Greater_Than_or_Equal_to_210_Days() => 
		__Has_ADHD_Cumulative_Medication_Duration_Greater_Than_or_Equal_to_210_Days.Value;

	private IEnumerable<Encounter> Inpatient_Stay_with_Qualifying_Diagnosis_During_Continuation_and_Maintenance_Phase_Value()
	{
		var a_ = this.Inpatient_Stay_with_Qualifying_Diagnosis();
		bool? b_(Encounter InpatientStay)
		{
			var d_ = InpatientStay?.Period;
			var e_ = FHIRHelpers_4_3_000.ToInterval(d_);
			var f_ = CQMCommon_2_0_000.ToDateInterval(e_);
			var g_ = context.Operators.Start(f_);
			var h_ = this.IPSD();
			var j_ = context.Operators.Quantity(300m, "days");
			var k_ = context.Operators.Add(h_, j_);
			var l_ = context.Operators.Interval(h_, k_, false, true);
			var m_ = context.Operators.In<CqlDate>(g_, l_, "day");
			var o_ = context.Operators.Not((bool?)(h_ is null));
			var p_ = context.Operators.And(m_, o_);

			return p_;
		};
		var c_ = context.Operators.Where<Encounter>(a_, b_);

		return c_;
	}

    [CqlDeclaration("Inpatient Stay with Qualifying Diagnosis During Continuation and Maintenance Phase")]
	public IEnumerable<Encounter> Inpatient_Stay_with_Qualifying_Diagnosis_During_Continuation_and_Maintenance_Phase() => 
		__Inpatient_Stay_with_Qualifying_Diagnosis_During_Continuation_and_Maintenance_Phase.Value;

	private bool? Initial_Population_2_Value()
	{
		var a_ = this.Patient();
		var b_ = context.Operators.Convert<CqlDate>(a_?.BirthDateElement?.Value);
		var c_ = this.Intake_Period();
		var d_ = context.Operators.Start(c_);
		var e_ = context.Operators.DateFrom(d_);
		var f_ = context.Operators.CalculateAgeAt(b_, e_, "year");
		var g_ = context.Operators.GreaterOrEqual(f_, 6);
		var i_ = context.Operators.Convert<CqlDate>(a_?.BirthDateElement?.Value);
		var k_ = context.Operators.End(c_);
		var l_ = context.Operators.DateFrom(k_);
		var m_ = context.Operators.CalculateAgeAt(i_, l_, "year");
		var n_ = context.Operators.LessOrEqual(m_, 12);
		var o_ = context.Operators.And(g_, n_);
		var p_ = this.Qualifying_Encounter();
		var q_ = context.Operators.Exists<Encounter>(p_);
		var r_ = context.Operators.And(o_, q_);
		var s_ = this.First_ADHD_Medication_Prescribed_During_Intake_Period();
		var t_ = context.Operators.Not((bool?)(s_ is null));
		var u_ = context.Operators.And(r_, t_);
		var v_ = this.Has_ADHD_Cumulative_Medication_Duration_Greater_Than_or_Equal_to_210_Days();
		var w_ = context.Operators.And(u_, v_);
		var x_ = this.Inpatient_Stay_with_Qualifying_Diagnosis_During_Continuation_and_Maintenance_Phase();
		var y_ = context.Operators.Exists<Encounter>(x_);
		var z_ = context.Operators.Not(y_);
		var aa_ = context.Operators.And(w_, z_);

		return aa_;
	}

    [CqlDeclaration("Initial Population 2")]
	public bool? Initial_Population_2() => 
		__Initial_Population_2.Value;

	private bool? Denominator_2_Value()
	{
		var a_ = this.Initial_Population_2();

		return a_;
	}

    [CqlDeclaration("Denominator 2")]
	public bool? Denominator_2() => 
		__Denominator_2.Value;

	private IEnumerable<CqlDate> Encounter_31_to_300_Days_into_Continuation_and_Maintenance_Phase_Value()
	{
		var a_ = this.Qualifying_Numerator_Encounter();
		bool? b_(Encounter ValidNumeratorEncounter)
		{
			var f_ = ValidNumeratorEncounter?.Period;
			var g_ = FHIRHelpers_4_3_000.ToInterval(f_);
			var h_ = CQMCommon_2_0_000.ToDateInterval(g_);
			var i_ = context.Operators.Start(h_);
			var j_ = this.IPSD();
			var k_ = context.Operators.Quantity(31m, "days");
			var l_ = context.Operators.Add(j_, k_);
			var n_ = context.Operators.Quantity(300m, "days");
			var o_ = context.Operators.Add(j_, n_);
			var p_ = context.Operators.Interval(l_, o_, true, true);
			var q_ = context.Operators.In<CqlDate>(i_, p_, "day");

			return q_;
		};
		var c_ = context.Operators.Where<Encounter>(a_, b_);
		CqlDate d_(Encounter ValidNumeratorEncounter)
		{
			var r_ = ValidNumeratorEncounter?.Period;
			var s_ = FHIRHelpers_4_3_000.ToInterval(r_);
			var t_ = context.Operators.Start(s_);
			var u_ = context.Operators.DateFrom(t_);

			return u_;
		};
		var e_ = context.Operators.Select<Encounter, CqlDate>(c_, d_);

		return e_;
	}

    [CqlDeclaration("Encounter 31 to 300 Days into Continuation and Maintenance Phase")]
	public IEnumerable<CqlDate> Encounter_31_to_300_Days_into_Continuation_and_Maintenance_Phase() => 
		__Encounter_31_to_300_Days_into_Continuation_and_Maintenance_Phase.Value;

	private bool? Two_or_More_Encounters_31_to_300_Days_into_Continuation_and_Maintenance_Phase_Value()
	{
		var a_ = this.Encounter_31_to_300_Days_into_Continuation_and_Maintenance_Phase();
		var b_ = context.Operators.Count<CqlDate>(a_);
		var c_ = context.Operators.GreaterOrEqual(b_, 2);

		return c_;
	}

    [CqlDeclaration("Two or More Encounters 31 to 300 Days into Continuation and Maintenance Phase")]
	public bool? Two_or_More_Encounters_31_to_300_Days_into_Continuation_and_Maintenance_Phase() => 
		__Two_or_More_Encounters_31_to_300_Days_into_Continuation_and_Maintenance_Phase.Value;

	private IEnumerable<CqlDate> Online_Assessment_31_to_300_Days_into_Continuation_and_Maintenance_Phase_Value()
	{
		var a_ = this.Online_Assessments();
		var b_ = context.Operators.RetrieveByValueSet<Encounter>(a_, null);
		bool? c_(Encounter OnlineAssessment)
		{
			var g_ = OnlineAssessment?.Period;
			var h_ = FHIRHelpers_4_3_000.ToInterval(g_);
			var i_ = CQMCommon_2_0_000.ToDateInterval(h_);
			var j_ = context.Operators.Start(i_);
			var k_ = this.IPSD();
			var l_ = context.Operators.Quantity(31m, "days");
			var m_ = context.Operators.Add(k_, l_);
			var o_ = context.Operators.Quantity(300m, "days");
			var p_ = context.Operators.Add(k_, o_);
			var q_ = context.Operators.Interval(m_, p_, true, true);
			var r_ = context.Operators.In<CqlDate>(j_, q_, "day");

			return r_;
		};
		var d_ = context.Operators.Where<Encounter>(b_, c_);
		CqlDate e_(Encounter OnlineAssessment)
		{
			var s_ = OnlineAssessment?.Period;
			var t_ = FHIRHelpers_4_3_000.ToInterval(s_);
			var u_ = context.Operators.Start(t_);
			var v_ = context.Operators.DateFrom(u_);

			return v_;
		};
		var f_ = context.Operators.Select<Encounter, CqlDate>(d_, e_);

		return f_;
	}

    [CqlDeclaration("Online Assessment 31 to 300 Days into Continuation and Maintenance Phase")]
	public IEnumerable<CqlDate> Online_Assessment_31_to_300_Days_into_Continuation_and_Maintenance_Phase() => 
		__Online_Assessment_31_to_300_Days_into_Continuation_and_Maintenance_Phase.Value;

	private bool? Numerator_2_Value()
	{
		var a_ = this.Encounter_During_Initiation_Phase();
		var b_ = context.Operators.Exists<Encounter>(a_);
		var c_ = this.Two_or_More_Encounters_31_to_300_Days_into_Continuation_and_Maintenance_Phase();
		var d_ = this.Encounter_31_to_300_Days_into_Continuation_and_Maintenance_Phase();
		IEnumerable<CqlDate> e_(CqlDate Encounter1)
		{
			var j_ = this.Online_Assessment_31_to_300_Days_into_Continuation_and_Maintenance_Phase();
			bool? k_(CqlDate Encounter2)
			{
				var o_ = context.Operators.Not((bool?)(Encounter1 is null));
				var p_ = context.Operators.Not((bool?)(Encounter2 is null));
				var q_ = context.Operators.And(o_, p_);
				var r_ = context.Operators.Equivalent(Encounter1, Encounter2);
				var s_ = context.Operators.Not(r_);
				var t_ = context.Operators.And(q_, s_);

				return t_;
			};
			var l_ = context.Operators.Where<CqlDate>(j_, k_);
			CqlDate m_(CqlDate Encounter2) => 
				Encounter1;
			var n_ = context.Operators.Select<CqlDate, CqlDate>(l_, m_);

			return n_;
		};
		var f_ = context.Operators.SelectMany<CqlDate, CqlDate>(d_, e_);
		var g_ = context.Operators.Exists<CqlDate>(f_);
		var h_ = context.Operators.Or(c_, g_);
		var i_ = context.Operators.And(b_, h_);

		return i_;
	}

    [CqlDeclaration("Numerator 2")]
	public bool? Numerator_2() => 
		__Numerator_2.Value;

	private Tuple_HPcCiDPXQfZTXIORThMLfTQDR SDE_Ethnicity_Value()
	{
		var a_ = SupplementalDataElements_3_4_000.SDE_Ethnicity();

		return a_;
	}

    [CqlDeclaration("SDE Ethnicity")]
	public Tuple_HPcCiDPXQfZTXIORThMLfTQDR SDE_Ethnicity() => 
		__SDE_Ethnicity.Value;

	private IEnumerable<Tuple_GPRWMPNAYaJRiGDFSTLJOPeIJ> SDE_Payer_Value()
	{
		var a_ = SupplementalDataElements_3_4_000.SDE_Payer();

		return a_;
	}

    [CqlDeclaration("SDE Payer")]
	public IEnumerable<Tuple_GPRWMPNAYaJRiGDFSTLJOPeIJ> SDE_Payer() => 
		__SDE_Payer.Value;

	private Tuple_HPcCiDPXQfZTXIORThMLfTQDR SDE_Race_Value()
	{
		var a_ = SupplementalDataElements_3_4_000.SDE_Race();

		return a_;
	}

    [CqlDeclaration("SDE Race")]
	public Tuple_HPcCiDPXQfZTXIORThMLfTQDR SDE_Race() => 
		__SDE_Race.Value;

	private CqlCode SDE_Sex_Value()
	{
		var a_ = SupplementalDataElements_3_4_000.SDE_Sex();

		return a_;
	}

    [CqlDeclaration("SDE Sex")]
	public CqlCode SDE_Sex() => 
		__SDE_Sex.Value;

}
