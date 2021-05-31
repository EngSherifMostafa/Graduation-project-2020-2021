SELECT *
FROM sys.dm_os_wait_stats dows where dows.wait_type like '%ram%'
ORDER BY dows.wait_type DESC;


SELECT dosi.physical_memory_kb, 
       dosi.virtual_memory_kb, 
       dosi.committed_kb, 
       dosi.committed_target_kb
FROM sys.dm_os_sys_info dosi;